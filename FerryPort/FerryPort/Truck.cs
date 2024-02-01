using System;

namespace FerryPort
{
    class Truck : Vehicle, ICargo
    {
        public Truck()
	    {
            _vehicleType = "truck";
	    }

        public void OpenCloseCargoDoor()
        {
            _doorState = !_doorState;
        }
    }
}
