using MediatR;

namespace GPSTracker.Application.Features.Devices.Events.LocationSaved
{
    public class LocationSavedEventHandler : INotificationHandler<LocationSavedEvent>
    {
        public Task Handle(LocationSavedEvent notification, CancellationToken cancellationToken)
        {
            //Retrieve all phone numbers registered to the device and send an SMS notification to each.
            Console.WriteLine("Send notification alert!");
            return Task.CompletedTask;
        }
    }
}
