using Application.Common;
using Application.Core.HelperClass;
using Application.Core.Mappings;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Domain.Enums;
using TransactionLog = Domain.Entities.TransactionLog;

namespace Application.Core.DTOs.TransactionDTOs
{
	public class TransactionDTO :  IMapFrom<TransactionLog>, IRequest
	{
		public TransactionDTO()
		{
            TransactionRefNumber = LogicHelper.GetTransactionId() ?? "";
            TransactionTime = DateTime.Now;

        }
		public Guid Id { get; set; }
		public DateTime TransactionTime { get; set; }

        public decimal TransactionAmount { get; set; }
        public TransStatus Status { get; set; }
        public Guid? TransactionTypeId { get; set; }  
        public decimal NewBalance { get; set; }
        public Guid AccountId { get; set; }
        public string TransactionDestinationAccount { get; set; }

        public string TransactionRefNumber { get; set; }

        public string UserId { get; set; }
        public bool IsSuccessful => Status.Equals(TransStatus.Successful);

    }
}
