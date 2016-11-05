using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XParkMinder.Domain.Library.Entities;

namespace XParkMinder.Domain.Library.Contracts
{
    public interface IParkingRepository : ISingleRepository<Parking>
    {}
}
