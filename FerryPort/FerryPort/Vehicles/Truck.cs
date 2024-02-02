using System;

namespace FerryPort
{
    class Truck : Cargo
    {
        public Truck()
	    {
            _vehicleType = "truck";
            _fuelMaxCapacity = 900f;
        }

    }
}
