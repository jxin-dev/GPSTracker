namespace GPSTracker.Domain.Entities
{
    public class Device
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string SerialNumber { get; private set; } = default!;

        // User
        public Guid? OwnerId { get; private set; } 
        public User? User { get; private set; }
        //
        public bool IsActive { get; private set; } = true;
        public DateTime RegisteredAt { get; private set; } = DateTime.UtcNow;

        private readonly List<DevicePhoneNumber> _devicePhoneNumbers = [];
        public IReadOnlyCollection<DevicePhoneNumber> DevicePhoneNumbers => _devicePhoneNumbers.AsReadOnly();

        private Device(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public static Device Create(string serialNumber)
        {
            return new Device(serialNumber);
        }

        public void BindToUser(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            OwnerId = user.Id;
            User = user;
        }

        public void AddPhoneNumber(string phoneNumber)
        {
            var devicePhoneNumber = DevicePhoneNumber.Create(this, phoneNumber);
            _devicePhoneNumbers.Add(devicePhoneNumber);
        }

    }
}
