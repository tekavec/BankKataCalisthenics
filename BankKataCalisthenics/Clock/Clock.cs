using System;

namespace BankKataCalisthenics.Clock
{
    public class Clock : IClock
    {
        public DateTime Today()
        {
            return DateTime.UtcNow;
        }
    }
}