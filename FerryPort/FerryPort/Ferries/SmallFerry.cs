using System;

namespace FerryPort
{
    class SmallFerry : Ferry
    {
        const float _carPrice = 3f;
        const float _vanPrice = 4f;

        public SmallFerry(int maxCapacity)
        {
            _maxCapacity = maxCapacity;
            _currentCapacity = maxCapacity;
        }

        public override void DetermineTicketPrice(Vehicle vehicle)
        {
            if(GetVehicleType(vehicle) == car)
                _transportationPrice = _carPrice;
            else if(GetVehicleType(vehicle) == van)
                _transportationPrice = _vanPrice;
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
