using System;
using System.Globalization;
using BankKataCalisthenics.Printer;
using BankKataCalisthenics.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankKataCalisthenics.Tests
{
    [TestClass]
    public class StatementLineShould
    {
        private readonly IFormatProvider _formatProvider = new CultureInfo("en-GB", true);

        [TestMethod]
        public void ReturnAStatementLineWithAGivenFormatProvider()
        {
            var transaction = new Transaction(1000m, new DateTime(2015, 9, 19));
            var statementLine = new StatementLine(transaction, 1500m);

            Assert.AreEqual(statementLine.CreateWith(_formatProvider), " | 19/09/2015 | 1,000.00 | 1,500.00");
        }
    }
}