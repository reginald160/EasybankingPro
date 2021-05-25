using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Domain.Enums;

namespace Domain.Entities
{
	public class Transaction : BaseModel
	{

        public DateTime TransactionTime { get; set; }

        public decimal TransactionAmount { get; set; }
        public TransStatus Status { get; set; }
		public Guid? TransactionTypeId { get; set; }
		[ForeignKey("TransactionTypeId")]
        public virtual TransactionType TransactionType { get; set; }
        public decimal NewBalance { get; set; }

        public Guid AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        public string TransactionDestinationAccount { get; set; }

        public string TransactionRefNumber { get; set; }

        public string UserId { get; set; }
		public bool IsSuccessful { get; set; }

	}
}
