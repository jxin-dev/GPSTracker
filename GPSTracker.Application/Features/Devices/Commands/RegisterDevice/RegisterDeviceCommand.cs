using GPSTracker.Contracts.Responses;
using MediatR;

namespace GPSTracker.Application.Features.Devices.Commands.RegisterDevice
{
    public record RegisterDeviceCommand(string SerialNumber) : IRequest<DeviceDto>;
}
