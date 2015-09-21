using System;
using System.Collections;
using System.Globalization;
using System.Text;
using NSubstitute;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BankKataCalisthenics.AcceptanceTests
{
    [Binding]
    public class AccountSteps
    {
        private readonly IBankConsole _console = Substitute.For<IBankConsole>();
        private Account _account;
        private readonly IClock _clock = Substitute.For<IClock>();
        private readonly IFormatProvider _cultureInfo = new CultureInfo("en-GB", true);
        private ITransactionRepository _transactionRepository;
        private IStatementPrinter _statementPrinter;

        [Given(@"that account is created")]
        public void GivenThatAccountIsCreated()
        {
            _statementPrinter = new StatementPrinter(_console);
            _transactionRepository = new TransactionRepository();
            _account = new Account(_clock, _transactionRepository, _statementPrinter);
            _account.PrintStatement();
        }
        
        [Given(@"a client makes a deposit of (.*) on '(.*)'")]
        public void GivenAClientMakesADepositOfOn(decimal amount, string date)
        {
            _clock.Today().Returns(ConvertStringToDateTime(date));
            _account.Deposit(amount);
        }

        [Given(@"a deposit of (.*) on '(.*)'")]
        public void GivenADepositOfOn(decimal amount, string date)
        {
            _clock.Today().Returns(ConvertStringToDateTime(date));
            _account.Deposit(amount);
        }
        
        [Given(@"a withdrawal of (.*) on '(.*)'")]
        public void GivenAWithdrawalOfOn(decimal amount, string date)
        {
            _clock.Today().Returns(ConvertStringToDateTime(date));
            _account.Withdraw(amount);
        }
        
        [When(@"she prints her bank statement")]
        public void WhenShePrintsHerBankStatement()
        {
            _account.PrintStatement();
        }
        
        [Then(@"she would see")]
        public void ThenSheWouldSee(Table table)
        {
            var header = new StringBuilder();
            foreach (var headerItem in table.Header)
            {
                header.Append(" | ").Append(headerItem);
            }
            _console.Received().WriteLine(header.ToString());
            var expectedStatementLines = table.CreateSet<StatementLine>();
            foreach (var expectedStatementLine in expectedStatementLines)
            {
                var statementLine = string.Format(" | {0} | {1} | {2}", expectedStatementLine.Date, expectedStatementLine.Amount, expectedStatementLine.Balance);
                _console.Received().WriteLine(statementLine);
            }
        }

        private DateTime ConvertStringToDateTime(string date)
        {
            return Convert.ToDateTime(date, _cultureInfo);
        }
    }

    public class StatementLine
    {
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
    }
}
