using System;

namespace FerryPort
{
    class Ferry
    {
        protected int _capacity;
        float _transportationPrice;

        const float _carPrice = 3;
        const float _busPrice = 4;
        const float _vanPrice = 5;
        const float _truckPrice = 6;

        float _revenue = 0;

        public int GetCapacity()
        {
            return _capacity;
        }

        public float GetTrasportationPrice()
        {
            return _transportationPrice;
        }

        public void SetTransportationPrice(Vehicle vehicle)
        {
            string typeOfVehicle = vehicle.GetVehicleType();

            // Price setting based on the type of the given vehicle
            if(typeOfVehicle == "car")
                _transportationPrice = _carPrice;
            else if(typeOfVehicle == "bus")
                _transportationPrice = _busPrice;
            else if(typeOfVehicle == "van")
                _transportationPrice = _vanPrice;
            else if(typeOfVehicle == "truck")
                _transportationPrice = _truckPrice;

            _revenue += _transportationPrice;

            Console.WriteLine($"Price for the {typeOfVehicle} is {_transportationPrice}");
        }

        public float ShowRevenue()
        {
            return _revenue;
        }
    }
}
