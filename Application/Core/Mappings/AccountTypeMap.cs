using Application.Core.DTOs.AccountTypeDTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mappings
{
	public class AccountTypeMap : Profile
	{
		public AccountTypeMap() => CreateMap<AccountType, AccountTypeDTO>().ReverseMap();

	}
}
