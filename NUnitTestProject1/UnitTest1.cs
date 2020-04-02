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

        [TestCase("Durham", 20.04, 1.503)]
        [TestCase("Wake", 15.06, 1.092)]
        public void Calculate_SalesTax_ReturnsCorrectSalesTax(string county, double total, double expected)
        {
            var controller = new SalesTaxController();
            var totalSalesTax = controller.SalesTax(county, total).TotalSalesTax;
            Assert.AreEqual(Math.Round(totalSalesTax, 3) , expected);
        }

        [TestCase("Durham", 20.04, 1.500)]
        [TestCase("Mecklenburg", 150.04, 10.40)]
        public void Calculate_SalesTax_ReturnsIncorrectSalesTax(string county, double total, double expected)
        {
            var controller = new SalesTaxController();
            var totalSalesTax = controller.SalesTax(county, total).TotalSalesTax;
            Assert.AreNotEqual(Math.Round(totalSalesTax, 3), expected);
        }
    }
}