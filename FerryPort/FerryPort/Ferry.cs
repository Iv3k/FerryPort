using System;

namespace FerryPort
{
    class Ferry
    {
        protected int _capacity;
        protected float _transportationPrice;
        protected float _revenue = 0;

        const float _busPrice = 4;
        const float _truckPrice = 6;

        public int GetCapacity()
        {
            return _capacity;
        }

        public virtual void SetTransportationPrice(Vehicle vehicle)
        {
            
        }

        public string GetVehicleType(Vehicle vehicle)
        {
            string typeOfVehicle = vehicle.GetVehicleType();

            return typeOfVehicle;
        }

        public bool CanBoardVehicle()
        {
            if(_capacity > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DecreaseCapacity()
        {
            _capacity--;
            Console.WriteLine($"Capacity {_capacity}");
        }

        public float ShowRevenue()
        {
            return _revenue;
        }
    }
}
