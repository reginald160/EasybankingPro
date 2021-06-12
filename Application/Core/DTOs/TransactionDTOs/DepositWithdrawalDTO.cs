using Application.Atributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.TransactionDTOs
{
	public class DepositWithdrawalDTO
	{
		[CoreAccountNumber, Required]
		public string AccountNumber { get; set; }
		[CoreAmount(0), Required, DataType(DataType.Currency)]
		public decimal Amount { get; set; }
	}
}
