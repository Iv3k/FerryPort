using System;

namespace FerryPort
{
    class TerminalClerk
    {
        float _income = 0;
        float _feeAmount = 0.10f;

        public void ShowIncome()
        {
            Console.WriteLine($"Clerk income {_income}");
        }

        public float GetFeeAmount()
        {
            return _feeAmount;
        }

        public void IncreaseIncome(float amount)
        {
            _income += amount;
        }
    }
}
