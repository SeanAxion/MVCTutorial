using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 1 || customer.MembershipTypeId == 0)
                return ValidationResult.Success;

            if (!customer.Birthdate.HasValue)
                return new ValidationResult("You must specify a birthdate");

            var age = DateTime.Now.Year - customer.Birthdate.Value.Year;

            return age <= 18 
                ? new ValidationResult("Customer must be at least 18 years of age.") 
                : ValidationResult.Success;

        }
    }
}