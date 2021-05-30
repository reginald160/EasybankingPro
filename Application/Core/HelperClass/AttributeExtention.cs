using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Core.HelperClass
{
    public class Nomenclature : ValidationAttribute
    {
        public bool _IsRequired { get; set; }
        public Nomenclature()
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value?.ToString()[0] != value?.ToString().ToUpper()[0])
            {
                return new ValidationResult("Value must start with capital letter");
            }
            if (value.ToString().Length > 20)
            {
                return new ValidationResult("Value must not be more more than 15 letters");
            }
            //if (_IsRequired.Equals(true) && value.ToString().Equals(String.Empty))
            //{

            //    return new ValidationResult($" The {validationContext.DisplayName} field is required");
            //}


            return ValidationResult.Success;
        }
    }

    public class CoreAccountNumber : ValidationAttribute
	{
		public CoreAccountNumber()
		{

		}
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
            Regex regex = new Regex(@"^5[0-9]{8}6$");

            bool isRegextMatch = regex.IsMatch(value.ToString());
            return regex.IsMatch(value.ToString()) ? ValidationResult.Success : new ValidationResult($"{validationContext.DisplayName} must be 10 digit number");


        }

    }


    public class PhoneNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value?.ToString()[0] != value?.ToString().ToUpper()[0])
            {
                return new ValidationResult("Value must start with capital letter");
            }
            if (value.ToString().Length > 20)
            {
                return new ValidationResult("Value must not be more more than 15 letters");
            }
            //if (_IsRequired.Equals(true) && value.ToString().Equals(String.Empty))
            //{

            //    return new ValidationResult($" The {validationContext.DisplayName} field is required");
            //}


            return ValidationResult.Success;
        }
    }

    public class FileUpload : ValidationAttribute
    {
        private readonly string[] _extensions;
        public FileUpload(string[] extensions)
        {
            _extensions = extensions;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            var extension = Path.GetExtension(file.FileName);
            if (file != null)
            {
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage(extension));
                }
            }

            return ValidationResult.Success;
        }
        public string GetErrorMessage(string extension)
        {
            return $"The .{extension} format of the file you are trying to upload is not allowed!";
        }
    }



}
