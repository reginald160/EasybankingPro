using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class NumberSequence : BaseModel
	{
		public string NumberSequenceName { get; set; }

		public string Module { get; set; }

		public string Prefix { get; set; }
		public int LastNumber { get; set; }
	}
}
