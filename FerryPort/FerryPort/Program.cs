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

            Vehicle car = new Car("car");
            Vehicle bus = new Bus("bus");
            Vehicle van = new Van("van");
            Vehicle truck = new Truck("truck");

            string loop = "gameOn";
            while (loop != "e")
            {
                smallFerry.SetTransportationPrice(car);
                smallFerry.SetTransportationPrice(bus);
                smallFerry.SetTransportationPrice(van);
                smallFerry.SetTransportationPrice(truck);

                Console.WriteLine($"Ferry revenue is {smallFerry.ShowRevenue()}");

                loop = Console.ReadLine();

            }

        }
    }
}
