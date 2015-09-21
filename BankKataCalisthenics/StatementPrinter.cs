using System;
using System.Globalization;
using System.Linq;

namespace BankKataCalisthenics
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
                var statementLine = string.Format(" | {0} | {1} | {2}", transaction.FormattedDate(_formatProvider),
                    transaction.FormattedAmount(_formatProvider), balance.ToString("N2", _formatProvider));
                _console.WriteLine(statementLine);
                balance -= transaction.Amount();
            }
        }

        public void PrintHeader()
        {
            _console.WriteLine(Header);
        }
    }
}