using System;

namespace FerryPort
{
    class Vehicle
    {
        protected bool _doorState;
        protected string _vehicleType;

        float _fuelMaxCapacity;
        float _currentFuel;

        public string GetVehicleType()
        {
            return _vehicleType;
        }

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
