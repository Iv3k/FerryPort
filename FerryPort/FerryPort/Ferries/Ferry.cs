using System;

namespace FerryPort
{
    class Ferry
    {
        protected int _capacity;
        protected float _transportationPrice;
        protected float _revenue = 0;

        public int GetCapacity()
        {
            return _capacity;
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
            if(_capacity > 0)
            {
                Console.WriteLine("Onboard...");
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
        }

        public void DecreaseRevenue(float amount)
        {
            _revenue -= amount;
        }

        public string ShowRevenue()
        {
            return $"$ {_revenue}";
        }
    }
}
