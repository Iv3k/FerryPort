using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FerryPort
{
    /// <summary>
    /// Interaction logic for FerryPort.xaml
    /// </summary>
    public partial class FerryPort : UserControl
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        List<Image> vehicleStatusImages = new List<Image>();

        Vehicle vehicle = new Vehicle();
        Ferry smallFerry = new Ferry();
        Ferry largeFerry = new Ferry();

        TerminalClerk clerk = new TerminalClerk();

        bool isGoodFuelLevel = true;
        bool canOnboard = false;
        int input = 0;

        string vehicleStatus = " ";
        const string carPath = "Images/car.png";
        const string vanPath = "Images/delivery.png";
        const string busPath = "Images/bus.png";
        const string truckPath = "Images/truck.png";

        public FerryPort()
        {
            InitializeComponent();
            VehiclesStatusImagesInit();

            vehicle = RandomVehicle(vehicles);
            vehicle.RandomizeFuelLevel();

            vehicleType.Content = vehicle.GetVehicleType();
            string fuelLevelValue = vehicle.GetFuelInPercentage().ToString();
            fuelLevelValue += " %";
            fuelLevel.Content = fuelLevelValue;

            ticketPrice.Content = vehicle.GetVehicleType();

        }

        private void OnProceedClick(object sender, RoutedEventArgs e)
        {
            input++;

            if(input==1)
            {
                vehicleStatus = "arrival";
                SetVehicleStatus();
            }
            else if(input==2)
            {
                vehicleStatus = "gas";
                SetVehicleStatus();
            }
            else if (input == 3)
            {
                vehicleStatus = "inspection";
                SetVehicleStatus();
            }
            else if (input == 4)
            {
                vehicleStatus = "ferry";
                SetVehicleStatus();
            }
            else if(input > 4)
            {
                input = 0;
            }
        }

        public void SetVehicleStatus()
        {   
            if (vehicleStatus == "arrival")
            {
                SetImageSource(vehicleArrivalImg);
            }
            else if(vehicleStatus == "gas")
            {
                SetImageSource(vehicleGasStationImg);
            }
            else if (vehicleStatus == "inspection")
            {
                SetImageSource(vehicleInspectionImg);
            }
            else if (vehicleStatus == "ferry")
            {
                SetImageSource(vehicleFerryImg);
            }
        }

        public string SetVehicleTypeImage(string type)
        {
            if (type == "car")
                return carPath;
            else if (type == "van")
                return vanPath;
            else if (type == "bus")
                return busPath;
            else
                return truckPath;
        }
        private void VehiclesStatusImagesInit()
        {
            vehicleStatusImages.Add(vehicleArrivalImg);
            vehicleStatusImages.Add(vehicleGasStationImg);
            vehicleStatusImages.Add(vehicleInspectionImg);
            vehicleStatusImages.Add(vehicleFerryImg);
        }
        private void SetImageSource(Image imagePlace)
        {
            // Recognizing vehicle type and setting image based on that
            string vehicleTypePath = SetVehicleTypeImage(vehicle.GetVehicleType());

            foreach (var img in vehicleStatusImages)
            {
                if (img == imagePlace)
                {
                    img.Source = new BitmapImage(new Uri(vehicleTypePath, UriKind.Relative));
                }
                else
                {
                    img.Source = null;
                }
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
