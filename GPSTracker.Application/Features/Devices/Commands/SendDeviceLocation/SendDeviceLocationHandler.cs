using GPSTracker.Domain.Entities;
using GPSTracker.Domain.Repositories;
using MediatR;

namespace GPSTracker.Application.Features.Devices.Commands.SendDeviceLocation
{
    public class SendDeviceLocationHandler : IRequestHandler<SendDeviceLocationCommand, Unit>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IDeviceRepository _deviceRepository;


        public SendDeviceLocationHandler(ILocationRepository locationRepository, IDeviceRepository deviceRepository)
        {
            _locationRepository = locationRepository;
            _deviceRepository = deviceRepository;
        }

        public async Task<Unit> Handle(SendDeviceLocationCommand request, CancellationToken cancellationToken)
        {
            var device = await _deviceRepository.GetDeviceBySerialNumber(request.SerialNumber);
            if (device is null)
            {
                throw new ArgumentNullException(nameof(device), "Device not found.");
            }
            var location = Location.Create(device, request.Latitude, request.Longitude);
            await _locationRepository.CreateAsync(location);
            return Unit.Value;
        }
    }
}
