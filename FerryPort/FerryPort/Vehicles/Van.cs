using System;

namespace FerryPort
{
    class Van : Vehicle, ICargo
    {
        public Van()
	    {
            _vehicleType = "van";
            _fuelMaxCapacity = 140f;
        }

        public void OpenCloseCargoDoor()
        {
            _doorState = !_doorState;
        }
    }
}
