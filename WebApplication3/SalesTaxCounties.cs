using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication3
{
    public class SalesTaxCounties
    {
        public List<SalesTaxCounty> Counties { get; set; }
    }

    public class SalesTaxCounty
    {
        public string CountyName { get; set; }
        public double SalesTaxPercentage { get; set; }
    }
}
