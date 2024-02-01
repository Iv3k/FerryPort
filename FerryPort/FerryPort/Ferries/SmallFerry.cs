using System;

namespace FerryPort
{
    class SmallFerry : Ferry
    {
        const float _carPrice = 3;
        const float _vanPrice = 4;

        public SmallFerry()
        {
            _capacity = 6;
        }

        public override void DetermineTicketPrice(Vehicle vehicle)
        {
            if(GetVehicleType(vehicle) == "car")
                _transportationPrice = _carPrice;
            else if(GetVehicleType(vehicle) == "van")
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
