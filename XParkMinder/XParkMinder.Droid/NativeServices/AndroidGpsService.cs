using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using XParkMinder.Geo.Contracts.ServiceLibrary.Contracts;
using XParkMinder.Geo.Contracts.ServiceLibrary.DTO;

namespace XParkMinder.Droid.NativeServices
{
    public class AndroidGpsService : IGpsService
    {
        private Context Context { get; }

        private LocationManager _locationManager = null;

        private string LocationProvider { get; set; }
        private LocationManager LocationManager => (_locationManager ?? (_locationManager = GetLocationManager(Context)));

        public AndroidGpsService(Context context)
        {
            Context = context;
        }


        public async Task<PortableLocation> GetGpsCurrentLocation()
        {
            var location = LocationManager.GetLastKnownLocation(LocationProvider);
            var result = ExpressMapper.Mapper.Map<Location, PortableLocation>(location);
            return await Task.FromResult<PortableLocation>(result);
        }

        LocationManager GetLocationManager(Context context)
        {
            var result = (LocationManager)context.GetSystemService(Context.LocationService);
            var criteriaForLocationService = new Criteria  { Accuracy = Accuracy.Fine };

            IList<string> acceptableLocationProviders = result.GetProviders(criteriaForLocationService, true);
            LocationProvider = acceptableLocationProviders.Any() ? acceptableLocationProviders.First() : string.Empty;

            Log.Debug("XParkMinder", "Using " + LocationProvider + ".");
            return result;
        }
    }
}