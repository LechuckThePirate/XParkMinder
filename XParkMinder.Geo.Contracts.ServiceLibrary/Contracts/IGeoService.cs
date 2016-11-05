using System.Threading.Tasks;
using XParkMinder.Geo.Contracts.ServiceLibrary.DTO;

namespace XParkMinder.Geo.Contracts.ServiceLibrary.Contracts
{
    public interface IGeoService
    {
        Task<PortableLocation> GetCurrentGPSPositionAsync();
        Task<string> GetGeocodedAddressAsync(PortableLocation location);
    }
}