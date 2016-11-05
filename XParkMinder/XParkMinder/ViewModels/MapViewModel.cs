using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XParkMinder.Application.Contracts.ServiceLibrary.Contracts;
using XParkMinder.Controls;
using XParkMinder.Geo.Contracts.ServiceLibrary.Contracts;
using XParkMinder.Views;

namespace XParkMinder.ViewModels
{
    public class MapViewModel : INotifyPropertyChanged
    {

        #region .: Fields :.

        private string _testText = string.Empty;
        private MapSpan _mapSpan;

        #endregion

        #region .: Services :.

        private IParkingService ParkingService { get; }
        private IGeoService GeoService { get; }

        #endregion

        #region .: Ctor :.

        public MapViewModel(IParkingService parkingService, IGeoService geoService)
        {
            ParkingService = parkingService;
            GeoService = geoService;

            GetLocationAddress();
        }

        #endregion

        #region .: Handlers :.

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region .: Properties :.
        public string TestText
        {
            get { return _testText; }
            set
            {
                _testText = value;
                OnPropertyChanged();
            }
        }

        public MapSpan MapSpan
        {
            get { return _mapSpan; }
            set
            {
                _mapSpan = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region .: Private Methods :.

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void GetLocationAddress()
        {
            TestText = "(Retrieving location)";

            var currentLocation = await GeoService.GetCurrentGPSPositionAsync();
            var currentAddress = await GeoService.GetGeocodedAddressAsync(currentLocation);

            TestText = currentAddress;
           
            MoveMapToNewLocation(currentLocation.Latitude, currentLocation.Longitude);
        }

        private void MoveMapToNewLocation(float latitude, float longitude)
        {
            MapSpan = MapSpan.FromCenterAndRadius(new Position(latitude, longitude), Distance.FromMeters(150));
        }

        #endregion

    }
}
