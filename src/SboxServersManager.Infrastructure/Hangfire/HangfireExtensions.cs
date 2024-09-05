using Hangfire;
using Hangfire.Redis.StackExchange;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Hangfire
{
    public static class HangfireExtensions
    {
        public static IServiceCollection AddHangfireServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(config =>
            {
                config.UseRedisStorage(configuration.GetConnectionString("HangfireRedis"), new RedisStorageOptions
                {
                    Prefix = "hangfire:",
                    InvisibilityTimeout = TimeSpan.FromMinutes(5)
                });
            });

            services.AddHangfireServer();

            return services;
        }
    }
}
