using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankKataCalisthenics.Tests
{
    [TestClass]
    public class TransactionShould
    {
        private readonly IFormatProvider _formatProvider = new CultureInfo("en-GB", true);
        private const decimal AmountA = 2000m;

        [TestMethod]
        public void ReturnADecimalAmount()
        {
            var transaction = new Transaction(AmountA, DateTime.Today);

            Assert.AreEqual(transaction.Amount(), AmountA);
        }

        [TestMethod]
        public void ReturnAFormattedAmount()
        {
            var transaction = new Transaction(AmountA, DateTime.Today);

            Assert.AreEqual(transaction.FormattedAmount(_formatProvider), "2,000.00");
        }

        [TestMethod]
        public void ReturnAFormattedDate()
        {
            var transaction = new Transaction(AmountA, new DateTime(2015, 9, 18));

            Assert.AreEqual(transaction.FormattedDate(_formatProvider), "18/09/2015");
        }
    }
}