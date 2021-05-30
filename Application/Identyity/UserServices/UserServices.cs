using Domain.Entities;
using Infrastructure.HelperClass;
using Infrastructure.Persistence.DataAccess;
using System;
using System.Collections.Generic;
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

		public UserServices(ApplicationDbContext db)
		{
			_db = db;
		}

		public Account AuthenticateAccount(string accountNumber, string pin)
		{
			var account = _db.Accounts.Where(x => x.AccountNumber.Equals(accountNumber)).SingleOrDefault();
			if (account == null) return null;

			//Verify Pin Hash
			if (!(IdentityLogicHelper.VerifyPinHash(pin, account.PINHash, account.PINSalt))) return null;

			return account; // return account on login success
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
	}
}
