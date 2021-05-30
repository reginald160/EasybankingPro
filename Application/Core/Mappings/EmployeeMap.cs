using Application.Core.DTOs.EmployeeDTO;
using Application.Core.HelperClass;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mappings
{
	public class EmployeeMap : Profile
	{
	
		public EmployeeMap()
		{
			CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
			CreateMap<Employee, GetAllEmployeeDTO>().ReverseMap();
				
		}
	}
}
