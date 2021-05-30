using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Account : AdminModel
	{
		public Account()
		{
			Transactions = new HashSet<TransactionLog>();

		}
		public string AccountNumber { get; set; }

		public Guid? CustomerId { get; set; }
		[ForeignKey("CustomerId")]
		[JsonIgnore]
		public Customer Customer { get; set; }
		public  decimal CurrentAccountBalance { get; set; }
		public Guid? AccountTypeId { get; set; }
		[ForeignKey("AccountTypeId")]
		[JsonIgnore]
		public AccountType AccountType { get; set; }
		public string UserName { get; set; }
		public byte[] PINHash { get; set; }
		public byte [] PINSalt { get; set; }
		public ICollection<TransactionLog> Transactions { get; set; }
		
	}
}
