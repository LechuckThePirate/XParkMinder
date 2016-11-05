using XParkMinder.Domain.Library.Entities;

namespace XParkMinder.AzureMobile.Infrastructure.ServiceLibrary.Repositories
{
    public class ParkingRepository : AzureMobileSingleRepository<Parking>
    {
        public ParkingRepository(ParkMinderDbContext context) : base(context) { }
    }
}
