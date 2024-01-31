using System;

namespace FerryPort
{
    class Bus : Vehicle, ICargo
    {
        public void OpenCloseCargoDoor()
        {
            _doorState = !_doorState;
        }
    }
}
