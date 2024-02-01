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
            Ferry smallFerry = new SmallFerry();
            Ferry largeFerry = new LargeFerry();

            Vehicle car = new Car();
            Vehicle bus = new Bus();
            Vehicle van = new Van();
            Vehicle truck = new Truck();

            TerminalClerk clerk = new TerminalClerk();

            string loop = "gameOn";
            while (loop != "e")
            {
                if(smallFerry.CanBoardVehicle())
                {
                    van.RandomizeFuelLevel();

                    // Arrival
                    smallFerry.DetermineTicketPrice(van);
                    //TODO
                    // Check fuel amount
                    Console.WriteLine($"Fuel level is on {van.GetFuelInPercentage()}%"); 
                    // Price determination
                    Console.WriteLine($"Ticket price {smallFerry.GetTicketPrice()}");
                    // Clerk's fee
                    float clerksCut = clerk.GetFeeAmount() * smallFerry.GetTicketPrice();
                    clerk.IncreaseIncome(clerksCut);
                    smallFerry.DecreaseRevenue(clerksCut);
                    // Onboarding
                    smallFerry.DecreaseCapacity();

                    clerk.ShowIncome();
                }
                else
                {
                    // In the future, add new ferry
                    Console.WriteLine("No more space in the ferry");
                }

                Console.WriteLine("\n");
                Console.WriteLine($"Small ferry revenue is {smallFerry.ShowRevenue()}");
                //Console.WriteLine($"Large ferry revenue is {largeFerry.ShowRevenue()}");

                loop = Console.ReadLine();

            }

        }
    }
}
