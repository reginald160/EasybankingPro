using Application.Common;
using Application.Core.HelperClass;
using Application.Core.Mappings;
using Application.Core.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.ViewModels.AccountViewModel
{
	public class CreateAccountDTO : AdminDTO , IMapFrom<Account>
	{
		Random rand = new Random();
		public CreateAccountDTO()
		{
			AccountNumber = LogicHelper.AccountNumberGenerator();
			
		}
	
		public string FirstName { get; set; }
		public string MiddleName { get; set; }

		public string LastName { get; set; }

		public string AccountNumber { get; set; }

		public Guid? CustomerId { get; set; }
		public string CustomerFullName { get; set; }
		public decimal CurrentAccountBalance { get; set; }
		public Guid? AccountTypeId { get; set; }
		 byte[] PINHash { get; set; }
		public byte[] PINSalt { get; set; }

		//public void Mapping(Profile profile )
		//{
		//	profile.CreateMap<CreateAccountDTO, Account>()
		//	.ForMember(x => x.FullName, o => o.MapFrom(s => s.FirstName + " " + s.MiddleName + " " + s.LastName));
			
		//}

	}
}
