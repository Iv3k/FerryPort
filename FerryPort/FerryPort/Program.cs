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
            List<Vehicle> vehicles = new List<Vehicle>();

            Vehicle vehicle = new Vehicle();
            Ferry smallFerry = new Ferry();
            Ferry largeFerry = new Ferry();

            Vehicle car = new Car();
            Vehicle bus = new Bus();
            Vehicle van = new Van();
            Vehicle truck = new Truck();

            TerminalClerk clerk = new TerminalClerk();

            string loop = "gameOn";
            while (loop != "e")
            {               
                // Store the value of the random vehicle from the to the vehicle object
                vehicle = RandomVehicle(vehicles, car, bus, van, truck);
                vehicle.RandomizeFuelLevel();
                Console.WriteLine($"Vehicle type {vehicle.GetVehicleType()}");

                if (smallFerry.GetCapacity() == 0)
                    smallFerry = new SmallFerry();

                if (largeFerry.GetCapacity() == 0)
                    largeFerry = new LargeFerry();

                // Check fuel amount
                int fuelLevel = vehicle.GetFuelInPercentage();
                //Console.WriteLine($"Fuel level is on {fuelLevel}%");
                /*if (clerk.NeedsRefuel(fuelLevel))
                {
                    Console.WriteLine("Tank refueled");

                }*/

                // Small ferry
                if (vehicle.GetVehicleType() == "car" || vehicle.GetVehicleType() == "van")
                {
                    // Check capacity
                    if (smallFerry.CanBoardVehicle())
                    {
                        smallFerry.DetermineTicketPrice(vehicle);

                        ClerkFee(smallFerry, clerk);

                        smallFerry.DecreaseCapacity();

                        Console.WriteLine($"Small ferry revenue is {smallFerry.ShowRevenue()}");
                    }

                }
                // Large ferry
                else if (vehicle.GetVehicleType() == "bus" || vehicle.GetVehicleType() == "truck")
                {
                    if (largeFerry.CanBoardVehicle())
                    {
                        largeFerry.DetermineTicketPrice(vehicle);

                        ClerkFee(largeFerry, clerk);

                        largeFerry.DecreaseCapacity();

                        Console.WriteLine($"Large ferry revenue is {largeFerry.ShowRevenue()}");
                    }
                }

                Console.WriteLine("\n");

                clerk.ShowIncome();
                loop = Console.ReadLine();
            }

        }

        private static Vehicle RandomVehicle(List<Vehicle> vehicles, Vehicle car, Vehicle bus, Vehicle van, Vehicle truck)
        {
            vehicles.Add(car);
            vehicles.Add(bus);
            vehicles.Add(van);
            vehicles.Add(truck);

            Random random = new Random();
            int randomVehicle = random.Next(vehicles.Count);

            return vehicles[randomVehicle];
        }

        private static void ClerkFee(Ferry ferry, TerminalClerk clerk)
        {
            float clerksCut = clerk.GetFeeAmount() * ferry.GetTicketPrice();
            clerk.IncreaseIncome(clerksCut);
            ferry.DecreaseRevenue(clerksCut);
        }
    }
}
