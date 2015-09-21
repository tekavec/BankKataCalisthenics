using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace BankKataCalisthenics.Tests
{
    [TestClass]
    public class AccountShould
    {
        private Account _account;
        private readonly IClock _clock = Substitute.For<IClock>();
        private readonly ITransactionRepository _transactionRepository = Substitute.For<ITransactionRepository>();
        private static readonly DateTime DateA = new DateTime(2015, 9, 15);
        private readonly Money _moneyA = new Money(1000m);
        private readonly Money _moneyB = new Money(-1000m);
        private readonly IStatementPrinter _statementPrinter = Substitute.For<IStatementPrinter>();

        [TestInitialize]
        public void Init()
        {
            _account = new Account(_clock, _transactionRepository, _statementPrinter);
        }

        [TestMethod]
        public void StoreADeposit()
        {
            var transaction = new Transaction(_moneyA, DateA);
            _clock.Today().Returns(DateA);

            _account.Deposit(_moneyA);

            _transactionRepository.Received().AddTransaction(transaction);
        }

        [TestMethod]
        public void StoreAWithdrawal()
        {
            var transaction = new Transaction(_moneyB, DateA);
            _clock.Today().Returns(DateA);

            _account.Withdraw(_moneyA);

            _transactionRepository.Received().AddTransaction(transaction);
        }

        [TestMethod]
        public void PrintAStatement()
        {
            _account.PrintStatement();

            _statementPrinter.Received().PrintFormattedStatement(_transactionRepository);
        }

    }
}
