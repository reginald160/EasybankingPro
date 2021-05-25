using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Enums
	{
		public enum Gender
		{
			Male, Female
		}
        public enum DesignitionCode
		{
            MD,RM,ZSM,BM,CSM,AO,SDSA,DSA

		}
        public enum TransStatus
        {
            Successful, Failed, Pending
        }

        public enum TransactionTypeDescription
        {
            Deposit, Withdrawal, Transfer
        }
        public enum AccountTypeDescription
        {
            Savings, Current, Fx, Kiddies, Dom
        }
        public enum IdentificationType
        {
            [Display(Name = "Voters card")]
            VotersCard,

            [Display(Name = "Internation Passport")]
            Passport,

            [Display(Name = "National Identity Card")]
            NIN,

            [Display(Name = "Drivers Lisence")]
            DriversLiscence,


        }
    }
}
