using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Responses
{
	public class WithdrawalDepositRespponse
	{
		public string AccountNumber { get; set; }
		public decimal Amount { get; set; }
		public decimal AccountBalance { get; set; }
		public string TransactionType { get; set; }
	}
}
