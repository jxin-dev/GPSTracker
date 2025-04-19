using GPSTracker.Contracts.Responses;
using GPSTracker.Domain.Entities;
using GPSTracker.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace GPSTracker.Application.Features.Devices.Commands.RegisterDevice
{
    public class RegisterDeviceHandler : IRequestHandler<RegisterDeviceCommand, DeviceDto>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public RegisterDeviceHandler(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<DeviceDto> Handle(RegisterDeviceCommand request, CancellationToken cancellationToken)
        {
            var newDevice = Device.Create(request.SerialNumber);
            await _deviceRepository.CreateAsync(newDevice);
            return _mapper.Map<DeviceDto>(newDevice);
        }
    }
}
