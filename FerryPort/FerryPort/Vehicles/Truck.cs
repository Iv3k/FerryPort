using System;

namespace FerryPort
{
    class Truck : Vehicle, ICargo
    {
        public Truck()
	    {
            _vehicleType = "truck";
            _fuelMaxCapacity = 900;
        }

        public void OpenCloseCargoDoor()
        {
            _doorState = !_doorState;
        }
    }
}
