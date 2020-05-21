using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (MembershipType.Unknown == customer.MembershipTypeId ||
                MembershipType.PayAsYouGo == customer.MembershipTypeId)
                return ValidationResult.Success;

            if (null == customer.DOB)
                return new ValidationResult("Birthdate is required");

            var age = DateTime.Today.Year - customer.DOB.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be atleast 18 years old to go on a membership");
        }
    }

}