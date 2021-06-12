using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Domain.Entities
{
	public class Customer : BaseProfile
	{
		public Guid? EmployeeId { get; set; }

		[ForeignKey("EmployeeId")]
		public virtual Employee AccountOfficer { get; set; }

		public string BrokerCode { get; set; }

		//public Guid? Accountd { get; set; }
		//[ForeignKey("Accountd")]

		//public virtual Account Account { get; set; }



	}
}
