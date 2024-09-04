using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Infrastructure.Repositories;

namespace SboxServersManager.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ServersManagerDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("SBox-SMM-ConnString")));

            services.AddScoped<IServerRepository, ServerRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IModRepository, ModRepository>();

            return services;
        }
    }
}
