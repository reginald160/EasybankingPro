using Application.Common;
using Application.Core.HelperClass;
using Application.Core.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Core.ViewModels.AccountViewModel
{
	public class CreateAccountDTO : BaseProfileDTO 
	{
		public string AccountNumber { get; set; }
		public Guid? EmployeeId { get; set; }
		public string BrokerCode { get; set; }
		public Guid? AccountTypeId { get; set; }
		public string UserName { get; set; }
		

	}
}
