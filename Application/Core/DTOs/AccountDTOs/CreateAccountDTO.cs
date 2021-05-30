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
	public class CreateAccountDTO : AdminDTO /*, IMapFrom<Account>*/
	{
		Random rand = new Random();
		public CreateAccountDTO()
		{
			AccountNumber = LogicHelper.AccountNumberGenerator();	
		}
		//[Nomenclature]
		public string FirstName { get; set; }
		//[Nomenclature]
		public string MiddleName { get; set; }
		[JsonIgnore]
		public string FullNamer => $"{FirstName} {MiddleName} {LastName} ";
		//[Nomenclature]
		public string LastName { get; set; }
		[JsonIgnore]
		public string AccountNumber { get; set; }
		[JsonIgnore]
		public Guid? CustomerId { get; set; }
		[JsonIgnore]
		public string CustomerFullName => $"{FirstName} {MiddleName} {LastName} ";
		
		public Guid? AccountTypeId { get; set; }
		public string UserName { get; set; }

		//[RegularExpression("@^[0-9]/d{4}$", ErrorMessage ="Pin must be 4 digits")]
		public  string Pin { get; set; }
		//[Compare("Pin", ErrorMessage ="Confirm does not match with the pin")]
		public string ConfirmPin { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Email { get; set; }
		public DateTime? DOB { get; set; }
		public string Phone { get; set; }
		public string BVN { get; set; }
		public IdentificationType? IdentificationType { get; set; }
		public string  IdentificationNum { get; set; }
		public string ImageUrl { get; set; }
		public Gender Gender { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap< Account, CreateAccountDTO>();
			//.ForMember(x => x.FullName, o => o.MapFrom(s => s.FirstName + " " + s.MiddleName + " " + s.LastName));

		}

	}
}
