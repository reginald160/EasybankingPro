using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Atributes
{
	public class CoreAccountNumber : ValidationAttribute
	{
		public CoreAccountNumber()
		{

		}
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			//Regex regex = new Regex(@"^5[0-9]{8}6$");
			Regex regex = new Regex(@"^[0-9]{10}$");
			return regex.IsMatch(value.ToString()) ? ValidationResult.Success : new ValidationResult($"{validationContext.DisplayName} must be 10 digit number");


		}

	}
	public class CoreAmount : ValidationAttribute
	{
		public int Min { get; set; }
		public CoreAmount(int min)
		{
			Min = min;
		}
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			
			var valueConvert = int.Parse(value.ToString());
			
			return valueConvert > Min ? ValidationResult.Success : new ValidationResult($"{validationContext.DisplayName} must be greather than {Min}");


		}

	}

}
