using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Domain.Entities
{
	public class Designition : AdminModel
	{
		public string Title { get; set; }

		public DesignitionCode Code { get; set; }
	}
}
