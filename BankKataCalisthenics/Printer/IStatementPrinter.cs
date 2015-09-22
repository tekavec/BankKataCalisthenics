using BankKataCalisthenics.Transactions;

namespace BankKataCalisthenics.Printer
{
    public interface IStatementPrinter
    {
        void PrintFormattedStatement(ITransactionRepository transactionRepository);
        void PrintHeader();
    }
}