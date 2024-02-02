using System;

namespace FerryPort
{
    class Vehicle
    {
        protected string _vehicleType;
        protected float _fuelMaxCapacity;
        protected float _currentFuel;

        public string GetVehicleType()
        {
            return _vehicleType;
        }
        
        public void RandomizeFuelLevel()
        {
            Random random = new Random();

            float randomFuel = (float)random.NextDouble() * _fuelMaxCapacity;

            _currentFuel = randomFuel;
        }

        public int GetFuelInPercentage()
        {
            return (int)Math.Round((_currentFuel / _fuelMaxCapacity) * 100); 
        }

    }
}
