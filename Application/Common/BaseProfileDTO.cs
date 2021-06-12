﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Common
{
	public class BaseProfileDTO : BaseDTO
	{
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Email { get; set; }
		public DateTime? DOB { get; set; }
		public string Phone { get; set; }
		public string BVN { get; set; }
		public IdentificationType? IdentificationType { get; set; }
		public string IdentificationNum { get; set; }
		public string ImageUrl { get; set; }
		public Gender Gender { get; set; }
	}
}
