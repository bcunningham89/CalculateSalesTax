using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace WebApplication3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesTaxController : ControllerBase
    {

        // GET: api/SalesTax?countyName=Durham&total=209.03
        [HttpGet]
        public CalculateSalesTax SalesTax(string countyName, double price)
        {
            var salesTaxClass = new CalculateSalesTax();

            if (string.IsNullOrEmpty(countyName))
            {

            }
            else
            {
                // Reading from a JSON file instead of hosting an actual db to look up the county's sales tax.
                using (StreamReader sr = new StreamReader("SalesTaxPercentagesByCounty.json"))
                {
                    var jsonString = sr.ReadToEnd();
                    var SalesTaxJSON = JsonSerializer.Deserialize<SalesTaxCounties>(jsonString);
                    var countySalesTax = SalesTaxJSON.Counties.Where(t => t.CountyName == countyName);
                    if (countySalesTax.Count() != 0)
                    {
                        var test = countySalesTax.First().SalesTaxPercentage;

                        salesTaxClass.RetailPrice = price;
                        salesTaxClass.TotalSalesTax = Math.Round(price * (test / 100), 2);
                        salesTaxClass.TotalAfterSalesTax = Math.Round(price + salesTaxClass.TotalSalesTax, 2);
                    }
                }
            }

            return salesTaxClass;
        }
    }
}
