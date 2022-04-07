using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalApp.Infrastructure.Data;

namespace RentalApp.WebApi.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<RentalAppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RentalAppCS")));
        }
    }
}
