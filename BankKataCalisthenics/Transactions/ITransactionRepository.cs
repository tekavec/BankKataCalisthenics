using System.Collections.Generic;

namespace BankKataCalisthenics.Transactions
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        IReadOnlyCollection<Transaction> AllTransactions();
        int Count();
        decimal CurrentBalance();
        IReadOnlyCollection<Transaction> AllTransactionsInReverseChronologicalOrder();
    }
}