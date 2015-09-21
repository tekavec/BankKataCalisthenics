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
        private readonly IStatementPrinter _statementPrinter = Substitute.For<IStatementPrinter>();
        private const decimal AmountA = 1000m;
        private const decimal AmountB = -1000m;

        [TestInitialize]
        public void Init()
        {
            _account = new Account(_clock, _transactionRepository, _statementPrinter);
        }

        [TestMethod]
        public void StoreADeposit()
        {
            var transaction = new Transaction(AmountA, DateA);
            _clock.Today().Returns(DateA);

            _account.Deposit(AmountA);

            _transactionRepository.Received().AddTransaction(transaction);
        }

        [TestMethod]
        public void StoreAWithdrawal()
        {
            var transaction = new Transaction(AmountB, DateA);
            _clock.Today().Returns(DateA);

            _account.Withdraw(AmountA);

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
