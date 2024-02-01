using System;

namespace FerryPort
{
    class Bus : Vehicle, ICargo
    {
        public Bus()
	    {
            _vehicleType = "bus";
	    }

        public void OpenCloseCargoDoor()
        {
            _doorState = !_doorState;
        }
    }
}
