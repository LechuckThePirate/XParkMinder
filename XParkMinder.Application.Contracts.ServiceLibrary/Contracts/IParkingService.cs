using XParkMinder.Application.Contracts.ServiceLibrary.DTO;

namespace XParkMinder.Application.Contracts.ServiceLibrary.Contracts
{
    public interface IParkingService
    {
        void RegisterParking(ParkingDTO parking);

        ParkingDTO GetLastParkedPosition();
    }
}
