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
        /*********************************************************************************************
        Purpose      :  To calculate the sales tax for a retail transaction based on the county that 
                        the transaction took place in.
        Parameters   :
            CountyName  - The County that the retail transaction is taking place.
            RetailPrice - The price of the transaction that the sales tax is going to be calculated.
        NOTE         : Most of the logic is being done in the controller.
                       In larger projects, this logic would be moved out into a differnt class/method.
        GET          : api/SalesTax?countyName=Durham&total=209.03
        **********************************************************************************************/
        [HttpGet]
        public SalesTaxResponse SalesTax(string countyName, double retailPrice)
        {
            var salesTaxResponse = new SalesTaxResponse();

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
                    var countySalesTaxes = SalesTaxJSON.Counties.Where(t => t.CountyName.ToUpper() == countyName.ToUpper());
                    if (countySalesTaxes.Count() != 0)
                    {
                        salesTaxResponse.SubTotal = retailPrice;
                        salesTaxResponse.CountySaleTaxPercentage = countySalesTaxes.First().SalesTaxPercentage;
                        salesTaxResponse.SalesTax = retailPrice * salesTaxResponse.CountySaleTaxPercentage / 100;
                        salesTaxResponse.Total = salesTaxResponse.SubTotal + salesTaxResponse.SalesTax;
                        return salesTaxResponse;
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
