using Application.Core.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity
{
	public static class UserRole
	{
		public const string Customer = Universe.CustomerRole;
		public const string Employee = Universe.EmployeeRole;
		public const string SuperAdmin = Universe.SuperAdminRole;
		public const string Admin = "Admin";
	}
}
