using System;

namespace BankKataCalisthenics.Transactions
{
    public class Money
    {
        private readonly decimal _amount;

        public Money(decimal amount)
        {
            _amount = amount;
        }

        public decimal Amount()
        {
            return _amount;
        }

        protected bool Equals(Money other)
        {
            return _amount == other._amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            return _amount.GetHashCode();
        }

        public string FormattedAmount(IFormatProvider formatProvider)
        {
            return _amount.ToString("N2", formatProvider);
        }
    }
}