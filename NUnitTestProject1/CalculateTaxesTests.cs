using NUnit.Framework;
using System;
using WebApplication3.Controllers;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Durham", 20.04, 1.50)]
        [TestCase("Wake", 15.06, 1.09)]
        public void Calculate_SalesTax_ReturnsCorrect(string county, double total, double expected)
        {
            var controller = new SalesTaxController();
            var totalSalesTax = controller.SalesTax(county, total).SalesTax;
            Assert.AreEqual(Math.Round(totalSalesTax, 2) , expected);
        }

        [TestCase("Wake", 56.97, 61.10)]
        [TestCase("Mecklenburg", 150.04, 160.92)]
        public void Calculate_TotalPrice_ReturnCorrect(string county, double total, double expected)
        {
            var controller = new SalesTaxController();
            var totalSalesTax = controller.SalesTax(county, total).Total;
            Assert.AreEqual(Math.Round(totalSalesTax, 2), expected);
        }


        [TestCase("Duplin", 0.00, 7.0)]
        [TestCase("Mecklenburg", 0.0, 7.25)]
        public void Calculate_SalesTaxPercentage_ReturnCorrect(string county, double total, double expected)
        {
            var controller = new SalesTaxController();
            var totalSalesTax = controller.SalesTax(county, total).CountySaleTaxPercentage;
            Assert.AreEqual(Math.Round(totalSalesTax, 2), expected);
        }
    }
}