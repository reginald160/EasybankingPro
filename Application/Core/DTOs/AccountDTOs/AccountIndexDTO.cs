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
		public Guid Id { get; set; }
		public string AccountNumber { get; set; }
		public string FullName { get; set; }
		public string AccountTypeTitle { get; set; }
		public string CustomerPhone { get; set; }
		public string CustomerPhoneEmail { get; set; }
		public decimal CurrentAccountBalance { get; set; }
		public string CustomerPhoneImageUrl { get; set; }
	
	}
}
