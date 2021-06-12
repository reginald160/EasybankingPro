using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.EmployeeDTO
{
	public class CreateEmployeeDTO : BaseProfileDTO
	{
		
		public string StaffCode { get; set; }
	}
}
