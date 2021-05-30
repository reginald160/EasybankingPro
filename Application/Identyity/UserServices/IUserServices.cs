using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identyity.UserServices
{
	public interface IUserServices
	{
		Account AuthenticateAccount(string accountNumber, string pin);

		Account CreatPin(Account account, string pin, string confirmPin);
	}
}
