using System;

namespace BankKataCalisthenics
{
    public class Clock : IClock
    {
        public DateTime Today()
        {
            return DateTime.UtcNow;
        }
    }
}