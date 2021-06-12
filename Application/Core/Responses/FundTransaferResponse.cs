using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Responses
{
	public class FundTransaferResponse 
	{
		public string SourceAccount { get; set; }
		public decimal Amount { get; set; }
		public decimal AccountBalance { get; set; }
		public string DestinationAccount { get; set; }
		public string TransactionType { get; set; }
	}
}
