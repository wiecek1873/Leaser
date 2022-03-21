using AutoMapper;
using RentalApp.Application.Dto;
using RentalApp.Domain.Entities;

namespace RentalApp.Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            })
            .CreateMapper();
    }
}
