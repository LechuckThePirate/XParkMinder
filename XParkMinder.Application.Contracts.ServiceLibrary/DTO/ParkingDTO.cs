using System;

namespace XParkMinder.Application.Contracts.ServiceLibrary.DTO
{
    public class ParkingDTO
    {
        public Guid Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public object Picture { get; set; }
        public string Comments { get; set; }
    }
}
