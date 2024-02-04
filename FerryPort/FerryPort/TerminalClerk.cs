using System;

namespace FerryPort
{
    class TerminalClerk
    {
        float _income = 0;
        const float _feeAmount = 0.10f;
        const int _fillingLimit = 10;
        const float _percentageOfNewFuel = 0.3f;

        public float ShowIncome()
        {
            // Max two decimals
            return float.Parse(_income.ToString("F2"));
        }

        public float GetFeeAmount()
        {
            return _feeAmount;
        }

        public void IncreaseIncome(float amount)
        {
            _income += amount;
        }

        public bool NeedsRefuel(int fuelLevel)
        {
            if (fuelLevel < _fillingLimit)
                return true;
            else
                return false;
        }

        // The clerk will always refuel at 30% of the maximum capacity
        public int NewAmountOfFuel(Vehicle vehicle)
        {
            float maxCapacity = vehicle.GetMaxCapacityOfFuel();
            int fuelToAdd = (int)( maxCapacity * _percentageOfNewFuel);

            return fuelToAdd;
        }

        public string CargoInspection(Vehicle vehicle)
        {
            // If given vehicle is cargo type the code will execute
            if(vehicle is Van van)
            {
                return van.OpenCloseDoor();
            }
            else if(vehicle is Truck truck)
            {
                return truck.OpenCloseDoor();
            }
            return "N/A";
        }

    }
}
