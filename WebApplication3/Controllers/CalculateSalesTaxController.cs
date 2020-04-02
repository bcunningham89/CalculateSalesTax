using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace WebApplication3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesTaxController : ControllerBase
    {
        // Parametersgittesting
        // GET: api/SalesTax?countyName=Durham&total=209.03
        [HttpGet]
        public CalculateSalesTax SalesTax(string countyName, double retailPrice)
        {
            var salesTaxClass = new CalculateSalesTax();

            if (string.IsNullOrEmpty(countyName))
            {
                throw new ArgumentException("Please ensure to input a County Name.");
            }
            else
            {
                // Reading from a JSON file instead of hosting an actual db to look up the county's sales tax.
                using (StreamReader sr = new StreamReader("SalesTaxPercentagesByCounty.json"))
                {
                    var jsonString = sr.ReadToEnd();
                    var SalesTaxJSON = JsonSerializer.Deserialize<SalesTaxCounties>(jsonString);
                    var countySalesTaxes = SalesTaxJSON.Counties.Where(t => t.CountyName == countyName);
                    if (countySalesTaxes.Count() != 0)
                    {
                        salesTaxClass.SubTotal = retailPrice;
                        salesTaxClass.CountySaleTaxPercentage = countySalesTaxes.First().SalesTaxPercentage;
                        salesTaxClass.SalesTax = retailPrice * salesTaxClass.CountySaleTaxPercentage / 100;
                        salesTaxClass.Total = salesTaxClass.SubTotal + salesTaxClass.SalesTax;
                        return salesTaxClass;
                    }
                    else
                    {
                        throw new ArgumentException("Please ensure you are using a County in NC and is spelled correctly.");
                    }
                }
            }
        }
    }
}
