using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryPort
{
    class Program
    {
        static void Main(string[] args)
        {
            Ferry smallFerry = new Ferry("small");

            Bus bus = new Bus();

            Console.WriteLine("Bus fuel level is " + bus.GetFuelState());
        }
    }
}
