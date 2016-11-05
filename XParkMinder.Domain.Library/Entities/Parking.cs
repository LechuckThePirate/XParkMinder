using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XParkMinder.Domain.Library.Entities
{
    public class Parking : BaseEntity
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public object Picture { get; set; }
        public string Comments { get; set; }
    }
}
