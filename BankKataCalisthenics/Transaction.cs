using System;

namespace BankKataCalisthenics
{
    public class Transaction
    {
        private readonly Money _money;
        private readonly DateTime _date;

        public Transaction(Money money, DateTime date)
        {
            _money = money;
            _date = date;
        }

        public Money Money
        {
            get { return _money; }
        }

        public DateTime Date
        {
            get { return _date; }
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