using System;
using System.Collections.Generic;
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

            TerminalClerk clerk = new TerminalClerk();

            string loop = "gameOn";
            while (loop != "e")
            {               
                // Store the value of the random vehicle from the list to the vehicle object
                vehicle = RandomVehicle(vehicles);
                vehicle.RandomizeFuelLevel();

                int fuelLevel = vehicle.GetFuelInPercentage();
                string vehicleType = vehicle.GetVehicleType();

                Console.WriteLine($"Vehicle type {vehicleType}");

                if (smallFerry.GetCapacity() == 0)
                    smallFerry = new SmallFerry();

                if (largeFerry.GetCapacity() == 0)
                    largeFerry = new LargeFerry();

                Console.WriteLine($"Fuel level is on {fuelLevel}%");
                /*if (clerk.NeedsRefuel(fuelLevel))
                {
                    Console.WriteLine("Tank refueled");

                }*/

                // Door manipulation
                clerk.CargoInspection(vehicle);

                // Small ferry
                if (vehicleType == "car" || vehicleType == "van")
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

        private static Vehicle RandomVehicle(List<Vehicle> vehicles)
        {
            vehicles.Clear();

            Vehicle car = new Car();
            Vehicle bus = new Bus();
            Vehicle van = new Van();
            Vehicle truck = new Truck();

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
