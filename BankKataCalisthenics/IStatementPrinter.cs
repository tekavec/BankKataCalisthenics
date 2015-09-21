namespace BankKataCalisthenics
{
    public interface IStatementPrinter
    {
        void PrintFormattedStatement(ITransactionRepository transactionRepository);
        void PrintHeader();
    }
}