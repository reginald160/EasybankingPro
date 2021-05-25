using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.HelperClass
{
	public static class Universe
	{
		public const string FirstUser = "Employee";
		public const string SecondUser = "Customer";
		public const string EmployeeNumenclature = "Emp";
		public static bool Deleted = true;
		public const string ColorGrey = "#808080";
		public const string ButtonRed = "btn-danger";
		public const string ButtonTheme = "btn-theme";
		public const string TextTheme = "text-primary";
		public const string TextRed = "text-danger";
		public const string ButtonGreen = "btn-primary";
		public const string ButtonBlue = "btn-secondary";
		public const string DeleteClature = "Deleted";
		private static string result;
		public static bool NewRecord = true;
		public const string Adminchars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		public static string EmployeeBaseDelete = "_unitOfWork.employee.Get(id)";
		public static string ApiKey = "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";
		public static Random AdminRandom = new Random();
		public static bool Truth = true;
		public static bool NotTrue = false;
		public static string Error500 = "Something Went Wrong";
		public static string APIBaseUrl = "https://localhost:44327";
		public static string UserScetionSeed = "Username";
		public static string AdminPass
		{
			get

			{
				result = LogicHelper.GetAdminPass();
				return result;
			}
			set
			{
				result = value;
			}
		}

	}
}
