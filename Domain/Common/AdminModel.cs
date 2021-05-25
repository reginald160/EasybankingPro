using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
	public class AdminModel : BaseModel
	{
		public string CreatedBy { get; set; }
		public DateTime DateCreated { get; set; }
		public string LastModifiedBy { get; set; }

		public DateTime? ModifiedDate{ get; set; }

	}
}
