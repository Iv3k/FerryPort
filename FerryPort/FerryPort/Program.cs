using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FerryPort
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var gui = new FerryPort();

            var window = new Window
            {
                Title = "Ferry Port",
                Content = gui,
                Width = 800,
                Height = 600
            };

            window.ShowDialog();

            List<Vehicle> vehicles = new List<Vehicle>();

            Vehicle vehicle = new Vehicle();
            Ferry smallFerry = new Ferry();
            Ferry largeFerry = new Ferry();

            TerminalClerk clerk = new TerminalClerk();

            bool isGoodFuelLevel = true;
            bool canOnboard = false;

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
                if (clerk.NeedsRefuel(fuelLevel))
                {
                    isGoodFuelLevel = false;

                    vehicle.RefuelTank(clerk.NewAmountOfFuel(vehicle));
                    Console.WriteLine("Tank refueled");
                    Console.WriteLine($"Fuel level is on {vehicle.GetFuelInPercentage()}%");
                    isGoodFuelLevel = true;
                    canOnboard = true;
                }
                else
                {
                    canOnboard = true;
                }

                if(isGoodFuelLevel && canOnboard)
                {
                    // Door manipulation
                    clerk.CargoInspection(vehicle);

                    // Small ferry
                    if (vehicleType == "car" || vehicleType == "van")
                    {
                        Onboarding(vehicle, smallFerry, clerk);
                    }
                    // Large ferry
                    else if (vehicleType == "bus" || vehicleType == "truck")
                    {
                        Onboarding(vehicle, largeFerry, clerk);
                    }
                }

                Console.WriteLine("\n");

                clerk.ShowIncome();
                loop = Console.ReadLine();
            }

        }

        private static void Onboarding(Vehicle vehicle, Ferry ferry, TerminalClerk clerk)
        {
            // Check capacity
            if (ferry.CanBoardVehicle())
            {
                ferry.DetermineTicketPrice(vehicle);

                ClerkFee(ferry, clerk);

                ferry.DecreaseCapacity();

                Console.WriteLine($"Ferry revenue is {ferry.ShowRevenue()}");
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
