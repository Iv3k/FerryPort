using System;

namespace FerryPort
{
    class Ferry
    {
        protected int _capacity;
        protected float _transportationPrice;

        const float _busPrice = 4;
        const float _truckPrice = 6;

        float _revenue = 0;

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

        public float ShowRevenue()
        {
            return _revenue;
        }
    }
}
