using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XParkMinder.Geo.Contracts.ServiceLibrary.Contracts;
using XParkMinder.Geo.Contracts.ServiceLibrary.DTO;

namespace XParkMinder.UWP.NativeServices
{
    public class UwpGpsService : IGpsService
    {
        public async Task<PortableLocation> GetGpsCurrentLocation()
        {
            return await Task.FromResult<PortableLocation>(null);
        }
    }
}
