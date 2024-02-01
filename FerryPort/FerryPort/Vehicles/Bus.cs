using System;

namespace FerryPort
{
    class Bus : Vehicle
    {
        public Bus()
	    {
            _vehicleType = "bus";
            _fuelMaxCapacity = 250f;
	    }
    }
}
