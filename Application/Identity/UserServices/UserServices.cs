using Application.Core.DTOs.IdentityUserDTO;
using Application.Core.HelperClass;
using Application.Core.Responses;
using Application.Identity;
using Application.Settings;
using AutoMapper.Configuration;
using Domain.Entities;
using Infrastructure.HelperClass;
using Infrastructure.Persistence;
using Infrastructure.Persistence.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identyity.UserServices
{
	public class UserServices : IUserServices
	{
		public virtual ClaimsPrincipal User { get; }
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IConfiguration _configuration;
		private readonly IOptions<JWTSettings>  _JWT;

		public UserServices(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWTSettings > jWT)
		{
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
			_JWT = jWT;
		}

		public async Task<Response> CreateUserASync(ApplicationUser user, string password, string role)
		{
			var userExists = await _userManager.FindByNameAsync(user.UserName);
			if (userExists != null)
				return CoreResponse.GlobalResponse(user, "User already exist", ResponseStatus.Failed, ResponseCode.InvalidCredential);

			var result = await _userManager.CreateAsync(user, password);
			if (!result.Succeeded)
				return CoreResponse.GlobalResponse(user, "Something went wrong", ResponseStatus.Failed, ResponseCode.FailedOperation);

				await _roleManager.CreateAsync(new IdentityRole(role));
			return CoreResponse.OnSuccess(user);
		}

		public async Task<Response> CreateAdminASync(ApplicationUser user, string password, string role)
		{
			var userExists = await _userManager.FindByNameAsync(user.UserName);
			if (userExists != null)
				return CoreResponse.GlobalResponse(user, "User already exist", ResponseStatus.Failed, ResponseCode.InvalidCredential);

			var result = await _userManager.CreateAsync(user, password);
			if (!result.Succeeded)
				return CoreResponse.GlobalResponse(user, "Something went wrong", ResponseStatus.Failed, ResponseCode.FailedOperation);

	
			if (!await _roleManager.RoleExistsAsync(UserRole.Admin))
				await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
			if (!await _roleManager.RoleExistsAsync(UserRole.Admin))
				await _roleManager.CreateAsync(new IdentityRole(UserRole.Employee));

			if (await _roleManager.RoleExistsAsync(UserRole.Admin))
				await _userManager.AddToRoleAsync(user, UserRole.Admin);

			return CoreResponse.OnSuccess(user);
		}


		public Account AuthenticateAccount(string accountNumber, string pin)
		{
			var account = _db.Accounts.Where(x => x.AccountNumber.Equals(accountNumber)).SingleOrDefault();
			if (account == null) return null;

			//Verify Pin Hash
			if (!(IdentityLogicHelper.VerifyPinHash(pin, account.PINHash, account.PINSalt))) return null;

			return account; // return account on login success
		}

		public bool IsUniqueUser(string username)
		{
			var user = _userManager.Users.Where(x => x.Email.Equals(username)).FirstOrDefault();
			return user == null ? true : false;
		}


		public async Task<Response> LoginAsync(LoginDTO login)
		{
			var resss = _JWT.Value.ValidIssuer;
			var user = await _userManager.FindByNameAsync(login.UserName);
			if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
			{
				var userRoles = await _userManager.GetRolesAsync(user);
				var authClaims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.UserName),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				};

				foreach (var userRole in userRoles)
				{
					authClaims.Add(new Claim(ClaimTypes.Role, userRole));
				}

				var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JWT.Value.Secret));

				var tokenDescriptor = new JwtSecurityToken(
					issuer: _JWT.Value.ValidIssuer,
					audience: _JWT.Value.ValidIssuer,
					expires: DateTime.Now.AddHours(4),
					claims: authClaims,
					signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
					);
				var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

				return CoreResponse.GlobalResponse(token, "Login Success", ResponseStatus.Success, ResponseCode.SuccesFullOperation);

			}
			 return CoreResponse.GlobalResponse(user, "AccessDenied", ResponseStatus.Failed, ResponseCode.FailedOperation);


		}
		public async Task VerifyEmail(string email)
		{
			var user = await _userManager.FindByNameAsync(email);
			await _userManager.DeleteAsync(user);
		}

		public async Task DeleteUser(string email)
		{
			var user = await _userManager.FindByNameAsync(email);
			await _userManager.DeleteAsync(user);
		}


		public string GetUserId()
		{
			return User.Identity.Name;
		}

		public Account CreatPin(Account account, string pin, string confirmPin)
		{
			var userAccount = _db.Accounts.Where(x => x.AccountNumber.Equals(account.AccountNumber)).SingleOrDefault();
			if (userAccount == null) throw new ArgumentException("Account does not exist");

			byte[] pinHash, pinSalt;
			using (var hmac = new System.Security.Cryptography.HMACSHA512())
			{
				pinSalt = hmac.Key;
				pinHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
			}

			account.PINSalt = pinSalt;
			account.PINHash = pinHash;

			_db.Accounts.Update(account);
			_db.SaveChanges();

			return account;

		}

		public IEnumerable<ApplicationUser> GetAllUsers()
		{
			throw new NotImplementedException();
		}

		
	}
}
