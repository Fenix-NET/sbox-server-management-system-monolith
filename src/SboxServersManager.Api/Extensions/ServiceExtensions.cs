using Microsoft.EntityFrameworkCore;
using SboxServersManager.Infrastructure.Repositories;

namespace SboxServersManager.Api.Extensions
{
    internal static class ServiceExtensions
    {
        /// <summary>
        /// Настройка политики CORS.
        /// </summary>
        /// <param name="services"></param>
        internal static void ConfigurationCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("BaseCorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        /// <summary>
        /// Настройка интеграции IIS.
        /// </summary>
        /// <param name="services"></param>
        internal static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });
        /// <summary>
        /// Настройка подключения к PostgreSQL.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        internal static void ConfigureNpgsqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDbContext<ServersManagerDbContext>(opts =>
                opts.UseNpgsql(configuration.GetConnectionString("SboxSMSContext")));
    }
}
