using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Core.DTOs.TransactionTypeDTOs
{
	public class TransactionTypeDTO : AdminDTO
	{
		public string Title { get; set; }
		public TransactionTypeDescription Description { get; set; }
		public decimal Charge { get; set; }

	}
}
