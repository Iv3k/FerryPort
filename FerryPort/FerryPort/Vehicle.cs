using System;

namespace FerryPort
{
    class Vehicle
    {
        float _fuelMaxCapacity;
        float _currentFuel;

        public float GetFuelState()
        {
            return _currentFuel;
        }
    }
}
