using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryPort
{
    class Ferry
    {
        string _type;
        int _capacity;
        float _transportationPrice;

        const float _carPrice = 3;
        const float _busPrice = 4;
        const float _vanPrice = 5;
        const float _truckPrice = 6;

        public Ferry(string type)
        {
            _type = type;
            Console.WriteLine("Ferry is created");

            // To avoid misspelling problem
            string upperType = type.ToUpper();

            //Capacity setup based on the type
            if (upperType == "SMALL") { _capacity = 8; }
            else if (upperType == "LARGE") { _capacity = 6; }
        }

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

            Console.WriteLine($"Price for the {typeOfVehicle} is {_transportationPrice}");
        }
    }
}
