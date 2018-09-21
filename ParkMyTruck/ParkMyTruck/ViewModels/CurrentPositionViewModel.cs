using ParkMyTruck.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ParkMyTruck.ViewModels
{
    public class CurrentPositionViewModel: BaseViewModel
    {
        private Position Position { get; set; }
        bool canGeoLocalize = true;
        private string longitude;
        private string latitude;
        private string altitude;

        public string Longitude
        {
            get { return Longitude; }
            private set
            {
                if(Longitude != value)
                {
                    Longitude = value;
                    OnPropertyChanged("Longitude");
                }
            }
        }
        public string Latitude
        {
            get { return Latitude; }
            private set
            {
                if (Latitude != value)
                {
                    Latitude = value;
                    OnPropertyChanged("Latitude");
                }
            }
        }

        public string Altitude
        {
            get { return Altitude; }
            private set
            {
                if (Altitude != value)
                {
                    Altitude = value;
                    OnPropertyChanged("Altitude");
                }
            }
        }

        public ICommand GetCurrentPositionCommand { get; private set; }
        public CurrentPositionViewModel(Position position)
        {
            Title = "Current Position";
            Longitude = position.Longitude;
            Latitude = position.Latitude;
            Altitude = position.Altitude;
            GetCurrentPositionCommand = new Command(async () => await CurrentPositionAsync(), () => canGeoLocalize);
        }
        
        async Task CurrentPositionAsync()
        {
            CanInitiateGeoLocation(false);
            Longitude = string.Empty;
            Latitude = string.Empty;
            Altitude = string.Empty;

            //            
            Position position = await CurrentPosition();
            Longitude = position.Longitude;
            Latitude = position.Latitude;
            Altitude = position.Altitude;
            CanInitiateGeoLocation(true);
        }

        void CanInitiateGeoLocation (bool value)
        {
            canGeoLocalize = value;
            ((Command)GetCurrentPositionCommand).ChangeCanExecute();
        }
        public async Task<Position> CurrentPosition()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                Console.WriteLine("Avant GetLocationAsync");
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    var position = new Position
                    {
                        Latitude = location.Latitude.ToString(),
                        Longitude = location.Longitude.ToString(),
                        Altitude = location.Altitude.ToString()
                    };
                    return position; 
                }
                else
                {
                    Console.WriteLine("location est null");
                    var position = new Position
                    {
                        Latitude = "not defined",
                        Longitude = "not defined",
                        Altitude = "not defined"
                    };
                    return position;
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Console.WriteLine("Exception FeatureNotSupportedException");
                var position = new Position
                {
                    Latitude = "not defined",
                    Longitude = "not defined",
                    Altitude = "not defined"
                };
                return position;
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Console.WriteLine("Exception PermissionException");
                var position = new Position
                {
                    Latitude = "not defined",
                    Longitude = "not defined",
                    Altitude = "not defined"
                };
                return position;
            }
            catch (Exception ex)
            {
                // Unable to get location
                Console.WriteLine("Exception Unable to get location");
                var position = new Position
                {
                    Latitude = "not defined",
                    Longitude = "not defined",
                    Altitude = "not defined"
                };
                return position;
            }

        }
    }
}
