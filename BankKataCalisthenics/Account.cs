namespace BankKataCalisthenics
{
    public class Account
    {
        private readonly IClock _clock;
        private readonly ITransactionRepository _transactionRepository;

        public Account(IClock clock, ITransactionRepository transactionRepository)
        {
            _clock = clock;
            _transactionRepository = transactionRepository;
        }

        public void PrintStatement()
        {
            throw new System.NotImplementedException();
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