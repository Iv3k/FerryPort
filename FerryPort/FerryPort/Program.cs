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
            Ferry small = new SmallFerry();
            Ferry large = new LargeFerry();

            Vehicle car = new Car();
            Vehicle bus = new Bus();
            Vehicle van = new Van();
            Vehicle truck = new Truck();

            TerminalClerk clerk = new TerminalClerk();

            string loop = "gameOn";
            while (loop != "e")
            {
                if(large.CanBoardVehicle())
                {
                    bus.RandomizeFuelLevel();

                    // Arrival
                    large.SetTransportationPrice(bus);
                    //TODO
                    // Check fuel amount
                    Console.WriteLine($"Fuel level is on {bus.GetFuelInPercentage()}%"); 
                    // Price determination
                    Console.WriteLine($"Ticket price {large.GetTicketPrice()}");
                    // Clerk's fee
                    clerk.IncreaseIncome(large.GetTicketPrice());
                    // Onboarding
                    large.DecreaseCapacity();

                    clerk.ShowIncome();
                }
                else
                {
                    // In the future, add new ferry
                    Console.WriteLine("No more space in the ferry");
                }

                //Console.WriteLine("\n");
                //Console.WriteLine($"Small ferry revenue is {small.ShowRevenue()}");
                Console.WriteLine($"Large ferry revenue is {large.ShowRevenue()}");

                loop = Console.ReadLine();

            }

        }
    }
}
