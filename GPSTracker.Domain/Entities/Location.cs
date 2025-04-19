namespace GPSTracker.Domain.Entities
{
    public class Location
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid DeviceId { get; private set; }
        public Device Device { get; private set; }
        public double Latitude { get; private set; } = default!;
        public double Longitude { get; private set; } = default!;
        public DateTime Timestamp { get; private set; } = DateTime.UtcNow;

        private Location() { }
        private Location(Device device, double latitude, double longitude)
        {
            Device = device;
            DeviceId = device.Id;
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Location Create(Device device, double latitude, double longitude)
        {
            return new Location(device, latitude, longitude);
        }
    }
}
