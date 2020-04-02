using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3
{
    public class CalculateSalesTax
    {
        public double SubTotal { get; set; }

        public double CountySaleTaxPercentage { get; set; }
        
        public double SalesTax { get; set; }

        public double Total { get; set; }

        public string testGit {get; set;}
    }
}
