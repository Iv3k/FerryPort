using System;

namespace FerryPort
{
    class Ferry
    {
        protected int _maxCapacity;
        protected int _currentCapacity;
        protected float _transportationPrice;
        protected float _revenue = 0;

        protected const string car = "car";
        protected const string bus = "bus";
        protected const string van = "van";
        protected const string truck = "truck";

        public int GetMaxCapacity()
        {
            return _maxCapacity;
        }

        public int GetCurrentCapacity()
        {
            return _currentCapacity;
        }

        public virtual void DetermineTicketPrice(Vehicle vehicle)
        {
            
        }

        public virtual float GetTicketPrice()
        {
            return _transportationPrice;
        }

        public string GetVehicleType(Vehicle vehicle)
        {
            string typeOfVehicle = vehicle.GetVehicleType();

            return typeOfVehicle;
        }

        public bool CanBoardVehicle()
        {
            if(_maxCapacity > 0)
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
            _currentCapacity--;
        }

        public void DecreaseRevenue(float amount)
        {
            _revenue -= amount;
        }

        public string ShowRevenue()
        {
            return $"$ {_revenue:F1}";
        }
    }
}
