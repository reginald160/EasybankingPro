using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Domain.Entities
{
	public class AccountType : BaseModel
	{
		public AccountType()
		{
			Accounts = new HashSet<Account>();
		}
		public string Name { get; set; }
	
		public string Code { get; set; }

		public string Title { get; set; }
		
		public string AccountCode { get; set; }
		
		public AccountTypeDescription AccountTypeDescription { get; set; }

		public ICollection<Account> Accounts { get; set; }
		public decimal InterestRateId { get; set; }
		
	}
}
