using Application.Core.DTOs.TransactionTypeDTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mappings
{
	public class TransactionTypeMap : Profile
	{
		public TransactionTypeMap() => CreateMap<TransactionType, TransactionTypeDTO>().ReverseMap();

	}
}
