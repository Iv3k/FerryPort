using System;

namespace FerryPort
{
    class Bus : Vehicle, ICargo
    {
        public Bus()
	    {
            _vehicleType = "bus";
            _fuelMaxCapacity = 250;
	    }

        public void OpenCloseCargoDoor()
        {
            _doorState = !_doorState;
        }
    }
}
