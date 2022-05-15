using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Domain.Entities
{
	public class Customer : BaseProfile
	{
		public Guid? EmployeeId { get; set; }

		[ForeignKey("EmployeeId")]
		public virtual Employee AccountOfficer { get; set; }

		[JsonIgnore]
		public virtual ICollection<Account> BankAccounts { get; set; }
		[JsonIgnore]
		public virtual ICollection<Card> Cards { get; set; }
		



	}
}
