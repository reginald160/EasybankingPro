using Application.Core.DTOs.CustomerDTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mappings
{
	public class CustomerMap : Profile
	{
		public CustomerMap()
		{
			CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
		}
	}
}
