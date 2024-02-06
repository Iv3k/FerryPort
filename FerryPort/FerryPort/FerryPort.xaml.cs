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
    public enum Phases
    {
        arrival,
        gas,
        inspection,
        ferry
    }
    public partial class FerryPort : UserControl
    {
        #region("Lists")
        List<Vehicle> vehicles = new List<Vehicle>();
        List<Image> vehicleStatusImages = new List<Image>();
        #endregion
        #region("Objects init")
        Vehicle vehicle = new Vehicle();
        Ferry smallFerry = new Ferry();
        Ferry largeFerry = new Ferry();
        TerminalClerk clerk = new TerminalClerk();
        #endregion
        #region("Variables")
        bool isGoodFuelLevel = true;
        int vehicleFuelLevel = 0;
        string typeOfTheVehicle = "/";
        string vehicleStatus = "/";
        Phases nextPhase = Phases.arrival;
        int totalPhases = Enum.GetValues(typeof(Phases)).Length;
        #endregion
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
            VehiclesStatusImagesAddToList();           
        }

        private void OnProceedClick(object sender, RoutedEventArgs e)
        {
            CreateNewFerry();

            if (nextPhase == Phases.arrival)
            {
                CreateNewRandomVehicle();

                vehicleStatus = arrival;
                SetVehicleStatusImage();

                DisplayFuel();
                ClerkCheckFuel();

                if (isGoodFuelLevel && !VehicleIsCargo())
                    nextPhase = Phases.inspection;
                else if (isGoodFuelLevel && VehicleIsCargo())
                    nextPhase++;
            }
            else if (nextPhase == Phases.gas)
            {
                if (isGoodFuelLevel && !VehicleIsCargo())
                {
                    nextPhase = Phases.inspection;
                }
                else
                {
                    vehicleStatus = gasStation;
                    SetVehicleStatusImage();
                }
            }
            else if (nextPhase == Phases.inspection)
            {
                vehicleStatus = inspection;
                SetVehicleStatusImage();              
            }
            else if (nextPhase == Phases.ferry)
            {
                Onboarding();
                vehicleStatus = ferry;
                SetVehicleStatusImage();
            }
            else if ((int)nextPhase > totalPhases - 1)
            {
                nextPhase = Phases.arrival;
            }

            if (nextPhase == Phases.gas && !isGoodFuelLevel)
                return;
            else
                nextPhase = (Phases)(((int)nextPhase + 1) % totalPhases);

            clerkIncome.Content = clerk.ShowIncome();
        }

        private void Onboarding()
        {
            // Small ferry
            if (typeOfTheVehicle == car || typeOfTheVehicle == van)
            {
                StartOnboarding(vehicle, smallFerry, clerk);
                UpdateFerryHUD(smallFerry, smallFerryIncome, smallFerryCapacity);
            }
            // Large ferry
            else if (typeOfTheVehicle == bus || typeOfTheVehicle == truck)
            {
                StartOnboarding(vehicle, largeFerry, clerk);
                UpdateFerryHUD(largeFerry, largeFerryIncome, largeFerryCapacity);
            }
        }

        private void CreateNewRandomVehicle()
        {
            vehicle = RandomVehicle(vehicles);
            vehicle.RandomizeFuelLevel();

            typeOfTheVehicle = vehicle.GetVehicleType();
            vehicleType.Content = typeOfTheVehicle;
            doorStatus.Content = "N/A";
        }

        private void CreateNewFerry()
        {
            if (smallFerry.GetCurrentCapacity() == 0)
            {
                smallFerry = null;
                smallFerry = new SmallFerry(8);
            }
            if (largeFerry.GetCurrentCapacity() == 0)
            {
                largeFerry = null;
                largeFerry = new LargeFerry(6);
            }
        }

        private void UpdateFerryHUD(Ferry ferry, Label label, ProgressBar progressBar)
        {
            label.Content = ferry.ShowRevenue();
            progressBar.Maximum = ferry.GetMaxCapacity();
            progressBar.Value = ferry.GetMaxCapacity() - ferry.GetCurrentCapacity();
        }

        private bool VehicleIsCargo()
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
        }

        private void OnClickRefuel(object sender, RoutedEventArgs e)
        {
            if(vehicleStatus == gasStation)
            {
                vehicle.RefuelTank(clerk.NewAmountOfFuel(vehicle));

                DisplayFuel();
                isGoodFuelLevel = true;

                if (!VehicleIsCargo())
                    nextPhase = Phases.ferry;
                else
                    nextPhase = Phases.inspection;
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
            if (VehicleIsCargo())
                doorStatus.Content = clerk.CargoInspection(vehicle);
        }

        private void DisplayFuel()
        {
            vehicleFuelLevel = vehicle.GetFuelInPercentage();

            string fuelLevelValue = vehicleFuelLevel.ToString();
            fuelLevelValue += "%";
            fuelLevel.Content = fuelLevelValue;
        }

        private void SetVehicleStatusImage()
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

        private string GetVehicleImagePath(string type)
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

        private void VehiclesStatusImagesAddToList()
        {
            vehicleStatusImages.Add(vehicleArrivalImg);
            vehicleStatusImages.Add(vehicleGasStationImg);
            vehicleStatusImages.Add(vehicleInspectionImg);
            vehicleStatusImages.Add(vehicleFerryImg);
        }

        private void SetImageSource(Image imagePlace)
        {
            // Recognizing vehicle type and setting image path based on that
            string vehicleTypePath = GetVehicleImagePath(vehicle.GetVehicleType());
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

        private static void StartOnboarding(Vehicle vehicle, Ferry ferry, TerminalClerk clerk)
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
