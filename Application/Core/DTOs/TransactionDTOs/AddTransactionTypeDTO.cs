using Application.Common;
using Application.Core.Mappings;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Core.DTOs.TransactionDTOs
{
	public class AddTransactionTypeDTO : BaseDTO /*IRequest,  IMapFrom<TransactionType>*/
	{
		[Required]
		public string Title { get; set; }
		[Required]
		public TransactionTypeDescription Description { get; set; }
		[Required]
		public decimal Charge { get; set; }
	}
}
