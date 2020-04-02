using System.Collections.Generic;

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
