using System;

namespace FerryPort
{
    class TerminalClerk
    {
        float _income = 0;
        const float _feeAmount = 0.10f;
        const int _fillingLimit = 10;

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

        public bool CheckFuelLevel(int fuelLevel)
        {
            if (fuelLevel < _fillingLimit)
                return true;
            else
                return false;
        }
    }
}
