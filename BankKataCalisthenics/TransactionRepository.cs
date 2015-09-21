using System.Collections.Generic;
using System.Linq;

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

        public int Count()
        {
            return _transactions.Count;
        }

        public decimal CurrentBalance()
        {
            return _transactions.Sum(a => a.Amount());
        }
    }
}