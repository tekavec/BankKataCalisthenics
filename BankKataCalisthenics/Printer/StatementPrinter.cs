using System;
using System.Globalization;
using System.Linq;
using BankKataCalisthenics.Console;
using BankKataCalisthenics.Transactions;

namespace BankKataCalisthenics.Printer
{
    public class StatementPrinter : IStatementPrinter
    {
        private const string Header = " | Date | Amount | Balance";
        private readonly IBankConsole _console;
        private readonly IFormatProvider _formatProvider = new CultureInfo("en-GB", true);

        public StatementPrinter(IBankConsole console)
        {
            _console = console;
        }

        public void PrintFormattedStatement(ITransactionRepository transactionRepository)
        {
            PrintHeader();
            PrintStatementLines(transactionRepository);
        }

        private void PrintStatementLines(ITransactionRepository transactionRepository)
        {
            decimal balance = transactionRepository.CurrentBalance();
            foreach (var transaction in transactionRepository.AllTransactions.OrderByDescending(a => a.Date()))
            {
                var statementLine = new StatementLine(transaction, balance);
                _console.WriteLine(statementLine.CreateWith(_formatProvider));
                balance -= transaction.Amount();
            }
        }

        public void PrintHeader()
        {
            _console.WriteLine(Header);
        }
    }
}