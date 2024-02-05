﻿using System;
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
        //bool canOnboard = false;
        int vehicleFuelLevel = 0;
        int input = 0;
        string typeOfTheVehicle = "/";

        string vehicleStatus = "/";
        #region("Image paths")
        const string carPath = "Images/car.png";
        const string vanPath = "Images/delivery.png";
        const string busPath = "Images/bus.png";
        const string truckPath = "Images/truck.png";
        #endregion
        #region("Vehicle types")
        const string car = "car";
        const string van = "van";
        const string bus = "bus";
        const string truck = "truck";
        #endregion
        #region("Phases")
        const string arrival = "arrival";
        const string gasStation = "gas";
        const string inspection = "inspection";
        const string ferry = "ferry";
        #endregion
        public FerryPort()
        {
            InitializeComponent();
            VehiclesStatusImagesInit();

            vehicle = RandomVehicle(vehicles);
            vehicle.RandomizeFuelLevel();
            typeOfTheVehicle = vehicle.GetVehicleType();

        }

        private void OnProceedClick(object sender, RoutedEventArgs e)
        {
            input++;
            Console.WriteLine($"Input value: { input }");

            if (smallFerry.GetCurrentCapacity() == 0)
                smallFerry = new SmallFerry();

            if (largeFerry.GetCurrentCapacity() == 0)
                largeFerry = new LargeFerry();

            if (input == 1)
            {
                vehicleStatus = arrival;
                vehicleType.Content = typeOfTheVehicle;

                DisplayFuel();
                ClerkCheckFuel();
                CheckIfCargo();

                SetVehicleStatusImage();
            }
            else if(input == 2 && !isGoodFuelLevel)
            {
                vehicleStatus = gasStation;
                SetVehicleStatusImage();
            }
            else if (input == 3 && isGoodFuelLevel && CheckIfCargo())
            {
                vehicleStatus = inspection;
                SetVehicleStatusImage();
            }
            else if (input == 4 && isGoodFuelLevel)
            {
                vehicleStatus = ferry;
                // Small ferry
                if (typeOfTheVehicle == car || typeOfTheVehicle == van)
                {
                    Onboarding(vehicle, smallFerry, clerk);
                    UpdateFerryHUD(smallFerry, smallFerryIncome, smallFerryCapacity);
                }
                // Large ferry
                else if (typeOfTheVehicle == bus || typeOfTheVehicle == truck)
                {
                    Onboarding(vehicle, largeFerry, clerk);
                    UpdateFerryHUD(largeFerry, largeFerryIncome, largeFerryCapacity);
                }
                SetVehicleStatusImage();
            }
            else if(input > 4 && isGoodFuelLevel)
            {
                input = 0;
                doorStatus.Content = "N/A";
                vehicle = RandomVehicle(vehicles);
                vehicle.RandomizeFuelLevel();
                typeOfTheVehicle = vehicle.GetVehicleType();
            }

            clerkIncome.Content = clerk.ShowIncome();

        }

        private void UpdateFerryHUD(Ferry ferry, Label label, ProgressBar progressBar)
        {
            label.Content = ferry.ShowRevenue();
            progressBar.Maximum = ferry.GetMaxCapacity();
            progressBar.Value = ferry.GetMaxCapacity() - ferry.GetCurrentCapacity();
        }

        private bool CheckIfCargo()
        {
            if (vehicle is Cargo)
                return true;
            return false;          
        }

        private void ClerkCheckFuel()
        {
            if (clerk.NeedsRefuel(vehicleFuelLevel))
            {
                isGoodFuelLevel = false;
            }
            else
            {
                input = 2;
            }
        }

        private void OnClickRefuel(object sender, RoutedEventArgs e)
        {
            if(vehicleStatus == gasStation)
            {
                vehicle.RefuelTank(clerk.NewAmountOfFuel(vehicle));

                DisplayFuel();
                isGoodFuelLevel = true;
            }
        }

        private void OnClickInspect(object sender, RoutedEventArgs e)
        {
            if(vehicleStatus == inspection)
            {
                ShowDoorStatus();
            }
        }

        private void ShowDoorStatus()
        {
            if (CheckIfCargo())
                doorStatus.Content = clerk.CargoInspection(vehicle);
        }

        private void DisplayFuel()
        {
            vehicleFuelLevel = vehicle.GetFuelInPercentage();

            string fuelLevelValue = vehicleFuelLevel.ToString();
            fuelLevelValue += "%";
            fuelLevel.Content = fuelLevelValue;
        }

        public void SetVehicleStatusImage()
        {   
            if (vehicleStatus == arrival)
            {
                SetImageSource(vehicleArrivalImg);
            }
            else if(vehicleStatus == gasStation)
            {
                SetImageSource(vehicleGasStationImg);
            }
            else if (vehicleStatus == inspection)
            {
                SetImageSource(vehicleInspectionImg);
            }
            else if (vehicleStatus == ferry)
            {
                SetImageSource(vehicleFerryImg);
            }
        }

        public string SetVehicleTypeImage(string type)
        {
            if (type == car)
                return carPath;
            else if (type == van)
                return vanPath;
            else if (type == bus)
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
            // Recognizing vehicle type and setting image path based on that
            string vehicleTypePath = SetVehicleTypeImage(vehicle.GetVehicleType());
            // Ensuring that each vehicle phase always has only one vehicle
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
