using XParkMinder.Geo.Contracts.ServiceLibrary.DTO;

namespace XParkMinder.Geo.Contracts.ServiceLibrary.Contracts
{
    public interface IGpsService
    {
        PortableLocation GetGpsCurrentLocation();
    }
}