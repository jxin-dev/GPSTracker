using MediatR;

namespace GPSTracker.Application.Features.Devices.Commands.SendDeviceLocation
{
    public record SendDeviceLocationCommand(string SerialNumber, double Latitude, double Longitude): IRequest<Unit>;
}
