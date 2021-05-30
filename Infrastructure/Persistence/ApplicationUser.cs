using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence
{
	public class ApplicationUser : IdentityUser
	{
		public Guid? EmployeeId { get; set; }
		[ForeignKey("EmployeeId")]
		[JsonIgnore]
		public virtual Employee Employee { get; set; }
		public Guid? CustomerId { get; set; }
		[ForeignKey("CustomerId")]
		[JsonIgnore]
		public virtual Customer Customer { get; set; }
	}
}
