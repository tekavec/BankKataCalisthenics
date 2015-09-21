using System;

namespace BankKataCalisthenics
{
    public class Transaction
    {
        private readonly Money _money;
        private readonly DateTime _date;

        public Transaction(decimal amount, DateTime date)
        {
            _money = new Money(amount);
            _date = date;
        }

        public string FormattedAmount(IFormatProvider formatProvider)
        {
            return _money.FormattedAmount(formatProvider);
        }

        public DateTime Date()
        {
            return _date;
        }

        public string FormattedDate(IFormatProvider formatProvider)
        {
            return _date.ToString("d", formatProvider);
        }

        public decimal Amount()
        {
            return _money.Amount();
        }

        protected bool Equals(Transaction other)
        {
            return Equals(_money, other._money) && _date.Equals(other._date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Transaction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_money != null ? _money.GetHashCode() : 0)*397) ^ _date.GetHashCode();
            }
        }
    }
}