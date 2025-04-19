using GPSTracker.Application.Features.Devices.Events.LocationSaved;
using GPSTracker.Domain.Entities;
using GPSTracker.Domain.Repositories;
using MediatR;

namespace GPSTracker.Application.Features.Devices.Commands.SendDeviceLocation
{
    public class SendDeviceLocationHandler : IRequestHandler<SendDeviceLocationCommand, Unit>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IPublisher _publisher;

        public SendDeviceLocationHandler(ILocationRepository locationRepository, IDeviceRepository deviceRepository, IPublisher publisher)
        {
            _locationRepository = locationRepository;
            _deviceRepository = deviceRepository;
            _publisher = publisher;
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

            var locationSavedEvent = new LocationSavedEvent(device, location.Latitude, location.Longitude);
            await _publisher.Publish(locationSavedEvent, cancellationToken);

            return Unit.Value;
        }
    }
}
