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
            if (GetVehicleType(vehicle) == "bus")
                _transportationPrice = _busPrice;
            else if (GetVehicleType(vehicle) == "truck")
                _transportationPrice = _truckPrice;

            _revenue += _transportationPrice;
        }
    }
}
