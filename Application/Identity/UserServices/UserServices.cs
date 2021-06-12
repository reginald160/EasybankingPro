using Domain.Entities;
using Infrastructure.HelperClass;
using Infrastructure.Persistence;
using Infrastructure.Persistence.DataAccess;
using Microsoft.AspNetCore.Identity;
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

		public UserServices(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
		{
			_db = db;
			_userManager = userManager;
		}


		public async Task<ApplicationUser> Creatidentityuser(ApplicationUser user, string password)
		{
			var result = await _userManager.CreateAsync(user, password);
			if (result.Succeeded)
				return user;
			return null;
		}
		public Account AuthenticateAccount(string accountNumber, string pin)
		{
			var account = _db.Accounts.Where(x => x.AccountNumber.Equals(accountNumber)).SingleOrDefault();
			if (account == null) return null;

			//Verify Pin Hash
			if (!(IdentityLogicHelper.VerifyPinHash(pin, account.PINHash, account.PINSalt))) return null;

			return account; // return account on login success
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
