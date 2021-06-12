using Application.Core.DTOs.AccountDTOs;
using Application.Core.HelperClass;
using Application.Core.ViewModels.AccountViewModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mappings
{
	public class AccountMap : Profile
	{
		public AccountMap()
		{
			CreateMap<Account,AccountIndexDTO>().ReverseMap();

			CreateMap<UpdateAccountDTO, Account>().ReverseMap()
				.ForMember(x => x.AccountNumber, o => o.Ignore())
				.ForMember(x => x.Deleted, o => o.Ignore()).ReverseMap();

			CreateMap<Account, CreateAccountDTO>().ReverseMap()
				.ForMember(x=> x.Id, o=> o.Ignore())
				.ForMember(x => x.FullName, o => o.MapFrom(a=> a.FirstName + " " + a.MiddleName + " " + a.LastName))
				.ForMember(x=> x.AccountNumber, o=> o.MapFrom(a=> LogicHelper.AccountNumberGenerator()));

		}
	}
}
