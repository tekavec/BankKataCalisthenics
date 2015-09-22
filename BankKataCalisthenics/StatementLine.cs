using System;
using System.Text;

namespace BankKataCalisthenics
{
    public class StatementLine
    {
        private readonly Transaction _transaction;
        private readonly decimal _balance;

        public  StatementLine(Transaction transaction, decimal balance)
        {
            _transaction = transaction;
            _balance = balance;
        }

        public string CreateWith(IFormatProvider formatProvider)
        {
            var line = new StringBuilder();
            line
                .Append(" | ")
                .Append(_transaction.FormattedDate(formatProvider))
                .Append(" | ")
                .Append(_transaction.FormattedAmount(formatProvider))
                .Append(" | ")
                .Append(_balance.ToString("N2", formatProvider));
            return line.ToString();
                
        }
    }
}