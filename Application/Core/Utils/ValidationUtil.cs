﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Utils
{

    public static class ValidationUtil
    {
        public static bool IsObjectValid(object model)
        {
            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(model, validationContext, validationResults,
                true);
        }

         static bool IsEntityStateValid(object model)
        => ValidationUtil.IsObjectValid(model);


    }
}
