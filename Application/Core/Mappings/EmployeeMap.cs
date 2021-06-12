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
			//Create Employee MAp
			CreateMap<Employee, CreateEmployeeDTO>().ReverseMap()
				.ForMember(x=> x.Id, o=> o.Ignore())
				.ForMember(x=> x.Deleted, o=> o.MapFrom(e=> false))
				.ForMember(x=> x.FullName, o=> o.MapFrom(e=> e.FirstName + " " + e.MiddleName + " " + e.LastName));

			//GetAll Employee mapping
			CreateMap<Employee, GetAllEmployeeDTO>().ReverseMap();
				
		}
	}
}
