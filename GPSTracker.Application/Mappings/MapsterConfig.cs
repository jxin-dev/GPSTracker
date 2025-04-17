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

        }
    }
}
