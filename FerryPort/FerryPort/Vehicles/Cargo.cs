using System;

namespace FerryPort
{
    class Cargo : Vehicle
    {
        protected bool _isDoorClosed = true;

        public void OpenCloseDoor()
        {
            _isDoorClosed = !_isDoorClosed;
            string doorInfo = _isDoorClosed ? "Door is closed" : "Door is open";

            Console.WriteLine(doorInfo);
        }
    }
}
