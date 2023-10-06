using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.CustomValidations
{
    public class ValidateDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateInput = Convert.ToDateTime(value);
            if (dateInput >= DateTime.Now)
            {
                return new ValidationResult(this.ErrorMessage);
            }
            return null;
        }
    }
}