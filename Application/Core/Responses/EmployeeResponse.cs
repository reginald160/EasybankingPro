using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Responses
{
	public class EmployeeResponse
	{
		public string Name { get; set; }

		[Display(Name ="Staff Code")]
		public string StaffCode { get; set; }
	}
}
