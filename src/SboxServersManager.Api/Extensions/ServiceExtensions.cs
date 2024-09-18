using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using SboxServersManager.Api.Options;
using SboxServersManager.Infrastructure.Data;

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

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
        }
        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<ConnectionStrings>().Bind(configuration.GetSection("ConnectionStrings"));
            services.AddOptions<JwtSettings>().Bind(configuration.GetSection("JwtSettings"));
        }
    }
}
