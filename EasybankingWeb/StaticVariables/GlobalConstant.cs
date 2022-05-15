using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasybankingWeb.StaticVariables
{
	public static class GlobalConstant
	{
        public const string BankSystemEmail = "Easybanking01@gmail.com";

        public const string AdministratorRoleName = "Administrator";

        public const string TempDataErrorMessageKey = "ErrorMessage";
        public const string TempDataSuccessMessageKey = "SuccessMessage";

        public const string TempDataNoTwoFactorKey = "2FANotEnabled";
        public const string IgnoreTwoFactorWarningCookie = "IgnoreTwoFactorWarning";

        public const string CardExpirationDateFormat = "MM/yy";
        public const int CardValidityInYears = 4;
    }
}
