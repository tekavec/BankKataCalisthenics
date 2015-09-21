using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankKataCalisthenics.Tests
{
    [TestClass]
    public class TransactionRepositoryShould
    {
        private ITransactionRepository _transactionRepository;
        private readonly Transaction _transactionA = new Transaction(1000m, new DateTime(2015, 9, 10));
        private readonly Transaction _transactionB = new Transaction(3000m, new DateTime(2015, 8, 10));

        [TestInitialize]
        public void Init()
        {
            _transactionRepository = new TransactionRepository();
        }

        [TestMethod]
        public void StoreATransaction()
        {
            _transactionRepository.AddTransaction(_transactionA);

            Assert.AreEqual(1, _transactionRepository.Count());
            Assert.IsTrue(_transactionRepository.AllTransactions.Contains(_transactionA));
            Assert.IsFalse(_transactionRepository.AllTransactions.Contains(_transactionB));
        }

        [TestMethod]
        public void CountTheNumberOfAllTransactions()
        {
            _transactionRepository.AddTransaction(_transactionA);
            _transactionRepository.AddTransaction(_transactionB);

            Assert.AreEqual(2, _transactionRepository.Count());
        }

        [TestMethod]
        public void CalculateCurrentBalance()
        {
            _transactionRepository.AddTransaction(_transactionA);
            _transactionRepository.AddTransaction(_transactionB);

            Assert.AreEqual(_transactionRepository.CurrentBalance(), 4000m);
        }
    }
}