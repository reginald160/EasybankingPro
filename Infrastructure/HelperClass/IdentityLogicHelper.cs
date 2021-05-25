using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.HelperClass
{
	public static class IdentityLogicHelper
	{
		public static bool VerifyPinHash(string pin, byte[] pinHash, byte[] pinSalt)
		{
			if (String.IsNullOrWhiteSpace(pin)) throw new ArgumentNullException("pin");

			using (var hmac = new System.Security.Cryptography.HMACSHA512(pinSalt))
			{
				var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pin));
				for (int i = 0; i < computeHash.Length; i++)
				{
					if (computeHash[i] != pin[i]) return false;
				}
				
			}
			return true;
		}

	}
}
