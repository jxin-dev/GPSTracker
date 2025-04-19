using GPSTracker.Contracts.Pagination;
using GPSTracker.Contracts.Responses;
using GPSTracker.Domain.Entities;
using Mapster;

namespace GPSTracker.Application.Mappings
{
    public class MapsterConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserDto>();
            config.NewConfig<PagedResult<User>, PagedResult<UserDto>>();


            config.NewConfig<Device, DeviceDto>()
                .Map(dest => dest.DevicePhoneNumbers, src => src.DevicePhoneNumbers.ToList());

            config.NewConfig<PagedResult<Device>, PagedResult<DeviceDto>>()
                .Map(dest => dest.Items, src => src.Items.Select(device => device.Adapt<DeviceDto>()).ToList());
        }
    }
}
