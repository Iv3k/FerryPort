using System;

namespace FerryPort
{
    class Bus : Vehicle, ICargo
    {
        public Bus (string type)
	    {
            _vehicleType = type;
	    }

        public void OpenCloseCargoDoor()
        {
            _doorState = !_doorState;
        }
    }
}
