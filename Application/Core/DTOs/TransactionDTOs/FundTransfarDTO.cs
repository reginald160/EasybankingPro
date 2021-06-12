using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.TransactionDTOs
{
	public class FundTransfarDTO
	{
		[Required]
		public string SourceAccount { get; set; }
		[Required]
		public string DestinationAccount { get; set; }
		[Required]
		public decimal Amount { get; set; }
	}
}
