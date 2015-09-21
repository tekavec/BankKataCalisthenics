using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace BankKataCalisthenics.Tests
{
    [TestClass]
    public class StatementPrinterShould
    {
        private readonly IBankConsole _console = Substitute.For<IBankConsole>();
        private IStatementPrinter _statementPrinter;

        [TestInitialize]
        public void Init()
        {
            _statementPrinter = new StatementPrinter(_console);
        }

        private const string Header = " | Date | Amount | Balance";

        [TestMethod]
        public void PrintAHeaderToConsole()
        {
            _statementPrinter.PrintHeader();

            _console.Received().WriteLine(Header);
        }

        [TestMethod]
        public void PrintAFormattedStatementInReverseChronologicalOrder()
        {
            var transactionRepository = new TransactionRepository();
            transactionRepository.AddTransaction(new Transaction(1000m, new DateTime(2015,9,10)));
            transactionRepository.AddTransaction(new Transaction(-500m, new DateTime(2015,8,10)));
            transactionRepository.AddTransaction(new Transaction(2000m, new DateTime(2015,10,10)));

            _statementPrinter.PrintFormattedStatement(transactionRepository);

            _console.Received().WriteLine(Header);
            _console.Received().WriteLine(" | 10/10/2015 | 2,000.00 | 2,500.00");   
            _console.Received().WriteLine(" | 10/09/2015 | 1,000.00 | 500.00");   
            _console.Received().WriteLine(" | 10/08/2015 | -500.00 | -500.00");   
        }
    }
}