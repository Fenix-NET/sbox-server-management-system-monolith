using Microsoft.Extensions.DependencyInjection;
using SboxServersManager.Application.Interfaces;
using SboxServersManager.Application.Services;
using System.Reflection;

namespace SboxServersManager.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IServerManagementService, ServerManagementService>();
            services.AddScoped<ICharacterManagementService, CharacterManagementService>();
            services.AddScoped<IModManagementService, ModManagementService>();

            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            });

            return services;
        }
    }
}
