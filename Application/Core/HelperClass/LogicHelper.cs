using Domain.Entities;
using Infrastructure.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.HelperClass
{
	public static class LogicHelper
	{
		public static string AccountNumberGenerator()
		{
			var random = new Random(System.DateTime.Now.Millisecond);
			int generatedRandNum = random.Next(1, 505020040);

			var generatedRandNumToString = String.Format("{0:D9}", generatedRandNum);
			const int MaxLength = 8;

			if (generatedRandNumToString.Length > MaxLength)
				generatedRandNumToString = generatedRandNumToString.Substring(1, MaxLength);

			var accountNumber = "5" + generatedRandNumToString + "6";
		   // long accountNumber = long.Parse(stringConcat);

			return accountNumber;
		}

		public static string GetTransactionId()
		{
			var year = DateTime.Now.Month.ToString();
			var day = DateTime.Now.Day.ToString();
			return DateTime.Now.Year.ToString() + year + day + DateTime.Now.ToString("ddmmyyhhmmss");
		}

		


		public static string GetRequestId()
		{
			return $"{Guid.NewGuid().ToString()}";
		}

		public static void GetPinHash(string pin, out byte[] pinHash, out byte[] pinSalt)
		{
			using (var hmac= new System.Security.Cryptography.HMACSHA512())
			{
				pinSalt = hmac.Key;
				pinHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
			}
		}

		public static string GetAdminPass()
		{

			var month = DateTime.Now.Month;
			var day = DateTime.Now.Day + 3;
			var dayToString = day < 9 ? "0" + day.ToString() : day.ToString();
			var MonthTostring = day < 9 ? "0" + month.ToString() : month.ToString();
			var Admin = "CoreAdmin" + MonthTostring + dayToString;

			return Admin;
		}

		public static string GetAdminRandomPass(int length)
		{

			string randomPass = new string(Enumerable.Repeat(Universe.Adminchars, length)
			  .Select(s => s[Universe.AdminRandom.Next(s.Length)]).ToArray());

			return randomPass;
		}


		public  static string GetStaffCode(ApplicationDbContext _context, string module)
		{
			string result = String.Empty;
			try
			{
				int counter = 1;
				var numberSequence = _context.NumberSequences
					.Where(x => x.Module.Equals(module))
					.FirstOrDefault();

				if (numberSequence == null)
				{
					numberSequence = new NumberSequence();
					numberSequence.Module = module;
					Interlocked.Increment(ref counter);
					numberSequence.LastNumber = counter;
					numberSequence.NumberSequenceName = module;
					numberSequence.Prefix = module;

					_context.Add(numberSequence);
					_context.SaveChanges();
				}
				else
				{
					counter = numberSequence.LastNumber;

					Interlocked.Increment(ref counter);
					numberSequence.LastNumber = counter;

					_context.Update(numberSequence);
					_context.SaveChanges();
				}

				result = numberSequence.Prefix + counter.ToString().PadLeft(3, '0');
			}
			catch (Exception exp)
			{

				return exp.Message;
			}
			return result;
		}



	}
}
