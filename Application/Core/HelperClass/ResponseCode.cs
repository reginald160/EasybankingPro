using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.HelperClass
{
	public static class ResponseCode
	{
		public static int  AccountNumberNotFound = 002;
		public static int InvalidUser = 003;
		public static int UserNotFound = 004;
		public static int InvalidCredential = 005;
		public static int InvalidDepositAmount = 006;
		public static int TransactionFailure = 007;
		public static int TransactionSuccess = 008;
		public static int LowDebitAmount = 009;
		public static int InvalidWithdrawalAmount = 010;
		public static int SuccesFullOperation = 011;
		public static int FailedOperation = 012;





	}

	public static class ResponseMessage
	{
		public static string AccountNumberNotFound = "Invalid Account Number";
		public static int InvalidUser = 003;
		public static int UserNotFound = 004;
		public static int InvalidCredential = 005;
		public static string InvalidDepositAmount = "The deposit amount must be greather than 100";
		public static string TransactionFailureMessage = "Transaction Failed";
		public static string TransactionSuccessMessage = "SucessFull Transaction";
		public static string LowDebitAmountMessage = "The Amount to be withdrwal can not be greater than current balance";
		public static string InvalidWithdrawalAmountMessage = "";
		public static string SuccesFullOperationMessage = "Successful operation";




	}
}
