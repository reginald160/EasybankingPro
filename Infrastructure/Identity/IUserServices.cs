using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
	public interface IUserServices
	{
		//bool VerifyPin(string pin, byte[] pinHash, byte[] pinSalt);
		Account AuthenticateAccount(string accountNumber, string pin);

		Account CreatPin(Account account, string pin, string confirmPin);


	}
}
