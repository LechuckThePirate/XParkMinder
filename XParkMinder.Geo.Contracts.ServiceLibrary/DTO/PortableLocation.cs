namespace XParkMinder.Geo.Contracts.ServiceLibrary.DTO
{
    public class PortableLocation
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Accuracy { get; set; }
        public string Provider { get; set; }
        public float Speed { get; set; }
    }
}