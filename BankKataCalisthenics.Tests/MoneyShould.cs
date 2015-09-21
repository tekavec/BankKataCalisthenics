using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankKataCalisthenics.Tests
{
    [TestClass]
    public class MoneyShould
    {
        private readonly IFormatProvider _formatProvider = new CultureInfo("en-GB", true);

        [TestMethod]
        public void CreateFormattedAmount()
        {
            var money = new Money(3000m);

            Assert.AreEqual("3,000.00", money.FormattedAmount(_formatProvider));
        }
    }
}