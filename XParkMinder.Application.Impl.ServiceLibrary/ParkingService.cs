using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XParkMinder.Application.Contracts.ServiceLibrary.Contracts;
using XParkMinder.Application.Contracts.ServiceLibrary.DTO;

namespace XParkMinder.Application.Impl.ServiceLibrary
{
    public class ParkingService : IParkingService
    {
        public void RegisterParking(ParkingDTO parking)
        {
            Debug.WriteLine($"Register parking at {parking.Latitude:0.0000},{parking.Longitude:0.0000}");
        }

        public ParkingDTO GetLastParkedPosition()
        {
            Debug.WriteLine("Requested last parking location");
            return new ParkingDTO();
        }
    }
}
