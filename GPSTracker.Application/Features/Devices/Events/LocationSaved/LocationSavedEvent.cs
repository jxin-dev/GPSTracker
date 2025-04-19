using GPSTracker.Domain.Entities;
using MediatR;

namespace GPSTracker.Application.Features.Devices.Events.LocationSaved
{
    public class LocationSavedEvent : INotification
    {
        public Device Device { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public LocationSavedEvent(Device device, double latitude, double longitude)
        {
            Device = device;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
