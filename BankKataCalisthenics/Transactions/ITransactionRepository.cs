using System.Collections.Generic;

namespace BankKataCalisthenics.Transactions
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        IReadOnlyCollection<Transaction> AllTransactions { get; }
        int Count();
        decimal CurrentBalance();
    }
}