﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Account : BaseProfile
	{
		public Account()
		{
			Transactions = new HashSet<TransactionLog>();
			Cards = new HashSet<Card>();
		}
		public string AccountNumber { get; set; }
		public Guid? EmployeeId { get; set; }

		[ForeignKey("EmployeeId")]
		public virtual Employee AccountOfficer { get; set; }
		public Guid? CustomerId { get; set; }

		[ForeignKey("CustomerId")]
		public virtual Customer Customer { get; set; }
		public string BrokerCode { get; set; }
		public  decimal CurrentAccountBalance { get; set; }
		public Guid? AccountTypeId { get; set; }
		[ForeignKey("AccountTypeId")]
		public AccountType AccountType { get; set; }
		public string UserName { get; set; }
		public byte[] PINHash { get; set; }
		public byte [] PINSalt { get; set; }
		[JsonIgnore]
		public virtual ICollection<TransactionLog> Transactions { get; set; }
		[JsonIgnore]
		public virtual ICollection<Card> Cards { get; set; }

		

	}
}
