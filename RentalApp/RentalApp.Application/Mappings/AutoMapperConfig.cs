using AutoMapper;
using RentalApp.Application.Dto.Users;
using RentalApp.Application.Dto.Posts;
using RentalApp.Domain.Entities;

namespace RentalApp.Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<LoginUserDto, User>()
                    .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
                cfg.CreateMap<CreateUserDto, User>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

                cfg.CreateMap<Post, PostDto>();
                cfg.CreateMap<PostDto, Post>();
                cfg.CreateMap<CreatePostDto, Post>();
            })
            .CreateMapper();
    }
}
