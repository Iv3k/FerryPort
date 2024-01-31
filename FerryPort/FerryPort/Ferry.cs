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

        private void SetTransportationPrice(float price)
        {
            // TODO
            _transportationPrice = price;
        }
    }
}
