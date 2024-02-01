using System;

namespace FerryPort
{
    class LargeFerry : Ferry
    {
        const float _busPrice = 5;
        const float _truckPrice = 6;

        public LargeFerry()
        {
            _capacity = 8;
        }

        public override void SetTransportationPrice(Vehicle vehicle)
        {
            string typeOfVehicle = vehicle.GetVehicleType();

            if (typeOfVehicle == "bus")
                _transportationPrice = _busPrice;
            else if (typeOfVehicle == "truck")
                _transportationPrice = _truckPrice;
        }
    }
}
