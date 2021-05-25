using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
	public class AdminDTO : BaseDTO
	{
		public string CreatedBy { get; set; }
		public DateTime DateCreated { get; set; }
		public string LastModifiedBy { get; set; }

		public DateTime? ModifiedDate { get; set; }
	}
}
