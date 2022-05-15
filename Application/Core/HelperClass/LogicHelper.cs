using Domain.Entities;
using Infrastructure.Persistence.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

		public static class Generator
		{
			public static void Main()
			{
				var rsa = new RSACryptoServiceProvider(4096);
				var publicKey = rsa.ToXmlString(false);
				var privateKey = rsa.ToXmlString(true);
				Console.WriteLine($"Public key: {publicKey}");
				Console.WriteLine("=====================================================================");
				Console.WriteLine($"Private key: {privateKey}");
			}
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

		public static string StringEncoder(string value)
		{
			var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(value));
			return code;
		}
		public static string StringDecoder(string value)
		{
			var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(value));
			return code;
		}
		public static class FileUploader
		{
			public static string imageurl(IFormFile model)
			{
				var uploadDir = "images";
				var fileName = Path.GetFileNameWithoutExtension(model.FileName);
				var imageUrlpath = "/" + uploadDir + "/" + fileName;
				return imageUrlpath;
			}
			public static string FileUpload(IFormFile model, string foldername, string webRootPath)
			{
				var uploadDir = foldername;
				var fileName = Path.GetFileNameWithoutExtension(model.FileName);
				var extension = Path.GetExtension(model.FileName);
				fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
				var path = Path.Combine(webRootPath, uploadDir, fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					model.CopyToAsync(fileStream);

				}
				string imageUrl = "/" + uploadDir + "/" + fileName;

				return imageUrl;
			}
		


		}


	}
}
