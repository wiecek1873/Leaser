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
