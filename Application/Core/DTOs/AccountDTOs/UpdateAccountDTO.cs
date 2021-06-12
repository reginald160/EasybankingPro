using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Core.DTOs.AccountDTOs
{
	public class UpdateAccountDTO : BaseProfileDTO
	{
		[JsonIgnore]
		public string AccountNumber { get; set; }
		public Guid? EmployeeId { get; set; }
		public string BrokerCode { get; set; }
		public Guid? AccountTypeId { get; set; }

	}
}
