namespace BankKataCalisthenics
{
    public class Account
    {
        private readonly IClock _clock;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IStatementPrinter _statementPrinter;

        public Account(IClock clock, ITransactionRepository transactionRepository, IStatementPrinter statementPrinter)
        {
            _clock = clock;
            _transactionRepository = transactionRepository;
            _statementPrinter = statementPrinter;
        }

        public void PrintStatement()
        {
            _statementPrinter.PrintFormattedStatement(_transactionRepository);
        }

        public void Deposit(Money money)
        {
            _transactionRepository.AddTransaction(new Transaction(money, _clock.Today()));
        }

        public void Withdraw(Money money)
        {
            _transactionRepository.AddTransaction(new Transaction(new Money(-money.Amount), _clock.Today()));
        }
    }
}