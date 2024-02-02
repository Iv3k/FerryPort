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
            // Representing value to maximum two digits
            Console.WriteLine($"Clerk income {_income.ToString("F2")}");
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
            int fuelToAdd = (int)( maxCapacity * 0.3);

            return fuelToAdd;
        }

        public void CargoInspection(Vehicle vehicle)
        {
            // If given vehicle is cargo type the code will execute
            if(vehicle is Van van)
            {
                van.OpenCloseDoor();
            }
            else if(vehicle is Truck truck)
            {
                truck.OpenCloseDoor();
            }
            else
            {
                Console.WriteLine("Inspection is not required");
            }
        }

    }
}
