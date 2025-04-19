namespace GPSTracker.Domain.Entities
{
    public class DevicePhoneNumber
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid DeviceId { get; private set; } = default!;
        public Device Device { get; private set; }
        public string PhoneNumber { get; private set; } = default!;
        public DateTime RegisteredAt { get; private set; } = DateTime.UtcNow;

        private DevicePhoneNumber() { }
        private DevicePhoneNumber(Device device, string phoneNumber)
        {
            Device = device;
            DeviceId = device.Id;
            PhoneNumber = phoneNumber;
        }

        public static DevicePhoneNumber Create(Device device, string phoneNumber)
        {
            return new DevicePhoneNumber(device, phoneNumber);
        }
    }
}
