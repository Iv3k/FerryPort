﻿using System;
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
            Ferry small = new SmallFerry();
            Ferry large = new LargeFerry();

            Vehicle car = new Car();
            Vehicle bus = new Bus();
            Vehicle van = new Van();
            Vehicle truck = new Truck();

            string loop = "gameOn";
            while (loop != "e")
            {
                small.SetTransportationPrice(car);
                small.SetTransportationPrice(van);

                large.SetTransportationPrice(bus);
                large.SetTransportationPrice(truck);

                Console.WriteLine("\n");
                Console.WriteLine($"Small ferry revenue is {small.ShowRevenue()}");
                Console.WriteLine($"Large ferry revenue is {large.ShowRevenue()}");

                loop = Console.ReadLine();

            }

        }
    }
}
