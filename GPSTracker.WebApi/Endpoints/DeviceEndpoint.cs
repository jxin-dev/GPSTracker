using GPSTracker.Application.Features.Devices.Commands.RegisterDevice;
using GPSTracker.Application.Features.Devices.Commands.SendDeviceLocation;
using GPSTracker.Contracts.Requests;
using GPSTracker.WebApi.Abstractions;
using Mapster;
using MediatR;

namespace GPSTracker.WebApi.Endpoints
{
    public class DeviceEndpoint : IEndpoint
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/devices");

            group.MapPost("/", async (ISender sender, RegisterDeviceRequest request) =>
            {
                var command = request.Adapt<RegisterDeviceCommand>();
                var result = await sender.Send(command);
                return Results.Ok(result);
            });

            group.MapPost("/coordinates", async (ISender sender, DeviceLocationRequest request) =>
            {
                var command = request.Adapt<SendDeviceLocationCommand>();
                var result = await sender.Send(command);
                return Results.Ok(result);
            });
        }
    }
}
