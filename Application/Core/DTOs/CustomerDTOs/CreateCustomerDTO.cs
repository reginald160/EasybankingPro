using Application.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Core.DTOs.CustomerDTOs
{
	public class CreateCustomerDTO : BaseProfileDTO
	{
		public Guid? EmployeeId { get; set; }
		
		public string BrokerCode { get; set; }
		public Guid? AccountId { get; set; }
		public Guid? AccountTypeId { get; set; }
	
	}
}
