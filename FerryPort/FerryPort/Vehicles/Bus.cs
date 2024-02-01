using System;

namespace FerryPort
{
    class Bus : Vehicle, ICargo
    {
        public Bus()
	    {
            _vehicleType = "bus";
            _fuelMaxCapacity = 250f;
	    }

        public void OpenCloseCargoDoor()
        {
            _doorState = !_doorState;
        }
    }
}
