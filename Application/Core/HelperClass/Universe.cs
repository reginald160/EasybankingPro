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
		public static bool ISDeleted = true;
		public const string DeleteClature = "Deleted";
		private static string result;
		public static bool NewRecord = true;
		public const string Adminchars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		public static string EmployeeBaseDelete = "_unitOfWork.employee.Get(id)";
		public static Random AdminRandom = new Random();
		public static bool Truth = true;
		public static bool NotTrue = false;
		public static string Error500 = "Something Went Wrong";
		public static string APIBaseUrl = "https://localhost:44327";
		public static string UserScetionSeed = "Username";
		public static string SuccessStatus = "Success";
		public static string FailedStatus = "Failed";
		public const string CustomerRole = "Customer";
		public const string EmployeeRole = "Employee";
		public const string SuperAdminRole = "SuperAdmin";
		public const string AdminEmail = "Easybanking@gmail.com";
		

		public static DateTime Now
		{
			get
			{
				return DateTime.UtcNow;
			}
		}
	}
	public static class NameSpace
	{
		public const string ApplicationNamespace = "Application";
		public const string SystemNamespace = "EasybankingPro";
	}

	public static class CSSHTML
	{
		public const string ColorGrey = "#808080";
		public const string ButtonRed = "btn-danger";
		public const string ButtonTheme = "btn-theme";
		public const string TextTheme = "text-primary";
		public const string TextRed = "text-danger";
		public const string ButtonGreen = "btn-primary";
		public const string ButtonBlue = "btn-secondary";
	}
	public static class EmailMessages
	{
		public const string ConfirmEmailSubject = "BankSystem email confirmation";

		public const string EmailConfirmationMessage =
			"To access your BankSystem account, please confirm your email by <a href=\"{0}\">clicking here</a>.";

		public const string EmailConfirmationPage = "/Account/ConfirmEmail";

		public const string ReceiveMoneySubject = "You have received money";

		public const string ReceiveMoneyMessage =
			"You have received €{0}. Please log into your BankSystem account for additional information.";

		public const string SendMoneySubject = "You have sent money";

		public const string SendMoneyMessage =
			"You have transferred €{0} from your account. If this transaction is fraudulent, please contact our support center.";
	}

	public static class ModelConstants
	{
		public static class User
		{
			public const int FullNameMaxLength = 50;

			public const int PasswordMaxLength = 100;
			public const int PasswordMinLength = 6;

			public const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,100}$";

			public const string PasswordErrorMessage =
				"Password minimum length is 6 characters and it must contain at least one uppercase letter, one lowercase letter and one number.";
		}

		public static class BankAccount
		{
			public const int NameMaxLength = 35;
			public const int UniqueIdMaxLength = 34;
			public const int SwiftCodeMaxLength = 11;
			public const int CountryMaxLength = 35;
		}

		public static class Card
		{
			public const int NameMaxLength = 50;

			public const int ExpiryDateMaxLength = 5;
			public const int SecurityCodeMaxLength = 3;
		}

		public static class MoneyTransfer
		{
			public const int DescriptionMaxLength = 150;
			public const string MinStartingPrice = "0.01";
			public const string MaxStartingPrice = "79228162514264337593543950335";
		}
	}

	public static class Security
	{
		public static string ApiKey = "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";
		public static string AdminPass
		{
			get { return LogicHelper.GetAdminPass(); }
		}
	}
	public static class NotificationMessages
	{
		public const string BankAccountCreated = "Bank account created successfully";
		public const string BankAccountCreateError = "An error occured while creating bank account";

		public const string CardCreatedSuccessfully = "Card created successfully";
		public const string CardCreateError = "An error occured while creating card";
		public const string CardDoesNotExist = "Such card does not exist";
		public const string CardDeletedSuccessfully = "Card deleted successfully";
		public const string CardDeleteError = "An error occured while deleting card";

		public const string TryAgainLaterError =
			"Oops! Something went wrong! Please try again later. If this error continues to occur, please contact our support center";

		public const string InsufficientFunds = "Insufficient account balance. Please choose another account.";

		public const string NoAccountsError =
			"Looks like you don't have any accounts. Please feel free to create one and then come back again to process your payment.";

		public const string SuccessfulMoneyTransfer = "Money transfer was successful";

		public const string SameAccountsError =
			"The account which you are sending money from and the destination account must be different";

		public const string AccountDoesNotExist = "Account does not exist";

		public const string DestinationBankAccountDoesNotExist = "The specified destination account does not exist";

		public const string InvalidCredentials = "Invalid email or password";
		public const string PasswordChangeSuccessful = "Password changed successfully";

		public const string InvalidPassword = "Invalid password";

		public const string LoginLockedOut =
			"Your account is locked because of too many invalid login attempts. Please try again in a few minutes.";

		public const string TwoFactorAuthenticationCodeInvalid = "Invalid code";
		public const string TwoFactorAuthenticationEnabled = "Two-factor authentication enabled successfully";
		public const string TwoFactorAuthenticationDisabled = "Two-factor authentication disabled successfully";

		public const string TwoFactorAuthenticationDisableError =
			"An error occured while disabling two-factor authentication";

		public const string SessionExpired = "Session has expired. Please log in again.";

		public const string PaymentStateInvalid =
			"Payment details are invalid or have expired. Please try again later.";

		public const string SuccessfulRegistration =
				   "Thank you for your registration. To activate your account, please follow the link in the email we have sent you";

		public const string EmailVerificationLinkResentSuccessfully =
			"Account activation link sent successfully";

		public const string SuccessfulEmailVerification =
			"Account activated. You can now log in.";

		public const string EmailVerificationFailed =
			"An error occured while verifying your email. Please try again later and if this error continues to occur, contact our support center";

		public const string EmailAlreadyVerified = "Your email is already verified. You can log in.";

		public const string EmailVerificationRequired =
			"Your account is not activated. If you have not received the activation email, you can request a new one on this page.";
	}





}
