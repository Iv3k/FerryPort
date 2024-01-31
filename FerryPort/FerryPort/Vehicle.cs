using System;

namespace FerryPort
{
    class Vehicle
    {
        protected bool _doorState;

        float _fuelMaxCapacity;
        float _currentFuel;

        public float GetFuelState()
        {
            return _currentFuel;
        }

        public bool GetDoorState()
        {
            return _doorState;
        }
    }
}
