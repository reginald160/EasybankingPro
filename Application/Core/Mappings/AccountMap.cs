using Application.Core.DTOs.AccountDTOs;
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
			CreateMap<Account, CreateAccountDTO>().ReverseMap();

		}
	}
}
