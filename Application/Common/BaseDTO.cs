using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
	public class BaseDTO
	{
		[Key]
		public Guid Id { get; set; }
		public bool Deleted { get; set; }
		public bool NewRecord { get; set; }
	}
}
