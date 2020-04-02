using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3
{
    public class CalculateSalesTax : IValidatableObject
    {
        [Required]
        public double RetailPrice { get; set; }

        public double TotalSalesTax { get; set; }

        public double TotalAfterSalesTax { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RetailPrice < 0)
            {
                yield return new ValidationResult("The total price needs to be greater than zero.");
            }
        }
    }
}
