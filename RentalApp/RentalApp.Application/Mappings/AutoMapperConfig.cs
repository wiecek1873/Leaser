using AutoMapper;
using RentalApp.Domain.Entities;
using RentalApp.Application.Dto.Users;
using RentalApp.Application.Dto.Posts;
using RentalApp.Application.Dto.Addresses;
using RentalApp.Application.Dto.Deposits;

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

                cfg.CreateMap<Address, AddressDto>();
                cfg.CreateMap<AddressDto, Address>();
                cfg.CreateMap<RequestAddressDto, Address>();

                cfg.CreateMap<Deposit, DepositDto>();
                cfg.CreateMap<DepositDto, Deposit>();
                cfg.CreateMap<CreateDepositDto, Deposit>();
            })
            .CreateMapper();
    }
}
