using Microsoft.Extensions.DependencyInjection;
using SboxServersManager.Application.Interfaces;
using SboxServersManager.Application.Services;

namespace SboxServersManager.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IServerManagementService, ServerManagementService>();
            services.AddScoped<IPlayerManagementService, PlayerManagementService>();
            services.AddScoped<IModManagementService, ModManagementService>();

            return services;
        }
    }
}
