using System;

namespace FerryPort
{
    class Cargo : Vehicle
    {
        protected bool _isDoorClosed = true;

        public string OpenCloseDoor()
        {
            _isDoorClosed = !_isDoorClosed;
            string doorInfo = _isDoorClosed ? "Closed" : "Open";

            return doorInfo;
        }
    }
}
