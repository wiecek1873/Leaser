using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalApp.Application.Interfaces;
using RentalApp.Application.Mappings;
using RentalApp.Application.Services;
using RentalApp.Domain.Interfaces;
using RentalApp.Infrastructure.Repositories;
using RentalApp.WebApi.Filters;

namespace RentalApp.WebApi.Installers
{
	public class MvcInstaller : IInstaller
	{
		public void InstallServices(IServiceCollection services, IConfiguration Configuration)
		{
			services.AddTransient<IUsersService, UsersService>();
			services.AddTransient<IUsersRepository, UsersRepository>();
			services.AddTransient<ITokenService, TokenService>();
			services.AddTransient<IPostsService, PostsService>();
			services.AddTransient<IPostsRepository, PostsRepository>();
			services.AddTransient<IAddressesService, AddressesService>();
			services.AddTransient<IAddressesRepository, AddressesRepository>();
			services.AddTransient<IDepositsService, DepositsService>();
			services.AddTransient<IDepositsRepository, DepositsRepository>();
			services.AddTransient<IDepositStatusesService, DepositStatusesService>();
			services.AddTransient<IDepositStatusesRepository, DepositStatusesRepository>();
			services.AddTransient<ICategoriesService, CategoriesService>();
			services.AddTransient<ICategoriesRepository, CategoriesRepository>();
			services.AddTransient<IUserRatesService, UserRatesService>();
			services.AddTransient<IUserRatesRepository, UserRatesRepository>();
			services.AddTransient<IPaymentsService, PaymentsService>();
			services.AddTransient<IPaymentsRepository, PaymentsRepository>();

			services.AddSingleton(AutoMapperConfig.Initialize());
			services.AddMvc(options =>
			{
				options.Filters.Add(new GlobalExceptionFilter());
			});

			services.AddCors();
			services.AddControllers();
		}
	}
}
