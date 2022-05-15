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
        public enum ChatType
        {
            CustomerToUser,
            UserToUser,
            Group,
            Private
        }
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
        public enum RequestStatus
        {
            Successful, Failed, Pending
        }

        public enum UserDescriminator
        {
            Customer, Employee
        }

        public enum TransactionTypes
        {
            Deposit, Withdrawal, Transfer
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
