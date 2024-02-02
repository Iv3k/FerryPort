using System;

namespace FerryPort
{
    class Van : Cargo
    {
        public Van()
	    {
            _vehicleType = "van";
            _fuelMaxCapacity = 140f;
        }

    }
}
