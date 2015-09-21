using System.Collections.Generic;

namespace BankKataCalisthenics
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        IReadOnlyCollection<Transaction> AllTransactions { get; }
        int Count { get; }
    }
}