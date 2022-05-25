using AutoMapper;
using RentalApp.Domain.Entities;
using RentalApp.Application.Dto.Users;
using RentalApp.Application.Dto.Posts;
using RentalApp.Application.Dto.Addresses;
using RentalApp.Application.Dto.Categories;
using RentalApp.Application.Dto.UserRates;
using RentalApp.Application.Dto.Payments;
using RentalApp.Application.Dto.Transactions;

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
                cfg.CreateMap<UpdateUserDto, User>()
                    .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.NewPassword));

                cfg.CreateMap<Post, PostDto>();
                cfg.CreateMap<PostDto, Post>();
                cfg.CreateMap<RequestPostDto, Post>();

                cfg.CreateMap<Address, AddressDto>();
                cfg.CreateMap<AddressDto, Address>();
                cfg.CreateMap<RequestAddressDto, Address>();

                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<CategoryDto, Category>();
                cfg.CreateMap<RequestCategoryDto, Category>();

                cfg.CreateMap<UserRate, UserRateDto>();
                cfg.CreateMap<UserRateDto, UserRate>();
                cfg.CreateMap<CreateUserRateDto, UserRate>();
                cfg.CreateMap<UpdateUserRateDto, UserRate>();

                cfg.CreateMap<Payment, PaymentDto>();
                cfg.CreateMap<PaymentDto, Payment>();
                cfg.CreateMap<RequestPaymentDto, Payment>();

                cfg.CreateMap<Transaction, TransactionDto>();
                cfg.CreateMap<TransactionDto, Transaction>();
                cfg.CreateMap<RequestTransactionDto, Transaction>();
            })
            .CreateMapper();
    }
}
