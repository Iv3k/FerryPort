using System;

namespace FerryPort
{
    class LargeFerry : Ferry
    {
        const float _busPrice = 5;
        const float _truckPrice = 6;

        public LargeFerry()
        {
            _maxCapacity = 6;
            _currentCapacity = _maxCapacity;
        }

        public override void DetermineTicketPrice(Vehicle vehicle)
        {
            if (GetVehicleType(vehicle) == "bus")
                _transportationPrice = _busPrice;
            else if (GetVehicleType(vehicle) == "truck")
                _transportationPrice = _truckPrice;
            else
                Console.WriteLine("Wrong type of the vehicle!");

            _revenue += _transportationPrice;
        }

        public override float GetTicketPrice()
        {
            return base.GetTicketPrice();
        }
    }
}
