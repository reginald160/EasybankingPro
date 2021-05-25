using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Domain.Entities
{
	public class TransactionType : BaseModel
	{
		public string Title { get; set; }
		public TransactionTypeDescription Description { get; set; }
		public decimal Charge { get; set; }
	
	}
}
