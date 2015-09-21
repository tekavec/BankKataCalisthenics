using System.Collections.Generic;

namespace BankKataCalisthenics
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IList<Transaction> _transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public IReadOnlyCollection<Transaction> AllTransactions
        {
            get { return _transactions as IReadOnlyCollection<Transaction>; }
        }

        int ITransactionRepository.Count
        {
            get { return _transactions.Count; }
        }

    }
}