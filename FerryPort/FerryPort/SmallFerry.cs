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

        public override void SetTransportationPrice(Vehicle vehicle)
        {
            string typeOfVehicle = vehicle.GetVehicleType();

            if(typeOfVehicle == "car")
                _transportationPrice = _carPrice;
            else if(typeOfVehicle == "van")
                _transportationPrice = _vanPrice;
        }
    }
}
