using Application.Common;
using Application.Core.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.AccountDTOs
{
	public class AccountIndexDTO 
	{
		public string AccountNumber { get; set; }
		public string AccountName { get; set; }
		public string AccountTypeName { get; set; }
		public string CustomerPhone { get; set; }
		public string CustomerPhoneEmail { get; set; }
		public decimal CurrentAccountBalance { get; set; }
		public string CustomerPhoneImageUrl { get; set; }
		public string NumberOfTransaction { get; set; }
		public ICollection<TransactionLog> Transactions { get; set; }

		//public AccountIndexDTO(Profile profile)
		//{
		//	profile.CreateMap<Account, AccountIndexDTO>();
		//}
		//public void Mapping(Profile profile)
		//{
		//	profile.CreateMap<Account, AccountIndexDTO>()
		//	.ForMember(a => a.AccountName, x => x.MapFrom(m => m.Customer.LastModifiedBy + " " + m.Customer.FirstName + " " + m.Customer.MiddleName))
		//	.ForMember(a => a.Transactions, x => x.MapFrom(m => m.Transactions.Where(t => t.AccountId.Equals(Id)).Where(x => x.Deleted.Equals(false))))
		//	.ForMember(a => a.NumberOfTransaction, x => x.MapFrom(m => m.Transactions.Count()));
		//}
	}
}
