using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using XParkMinder.Geo.Contracts.ServiceLibrary.Contracts;
using XParkMinder.Geo.Contracts.ServiceLibrary.DTO;

namespace XParkMinder.Geo.Impl.ServiceLibrary
{
    public class GeoService : IGeoService
    {
        private IGpsService GpsService { get; }

        public GeoService(IGpsService gpsService)
        {
            GpsService = gpsService;
        }

        public async Task<PortableLocation> GetCurrentGPSPositionAsync()
        {
            return await GpsService.GetGpsCurrentLocation();
        }

        public async Task<string> GetGeocodedAddressAsync(PortableLocation location)
        {
            var geoCoder = new Geocoder();
            var result = geoCoder.GetAddressesForPositionAsync(new Position(location.Latitude, location.Longitude));
            var list = await result;
            return list?.FirstOrDefault();
        }
    }
}
