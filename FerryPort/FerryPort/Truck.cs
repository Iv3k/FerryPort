using System;

namespace FerryPort
{
    class Truck : Vehicle, ICargo
    {
        public Truck (string type)
	    {
            _vehicleType = type;
	    }

        public void OpenCloseCargoDoor()
        {
            _doorState = !_doorState;
        }
    }
}
