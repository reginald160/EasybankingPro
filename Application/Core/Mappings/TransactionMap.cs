using Application.Core.DTOs.TransactionDTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mappings
{
	public class TransactionMap : Profile
	{
		public TransactionMap()
		{
			CreateMap<AccountType, AddTransactionTypeDTO>().ReverseMap();
		}
	}
}
