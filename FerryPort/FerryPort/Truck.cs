using System;

namespace FerryPort
{
    class Truck : Vehicle, ICargo
    {
        public void OpenCloseCargoDoor()
        {
            _doorState = !_doorState;
        }
    }
}
