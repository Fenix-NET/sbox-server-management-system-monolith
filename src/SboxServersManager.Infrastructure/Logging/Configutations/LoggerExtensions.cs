using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SboxServersManager.Infrastructure.Logging.Configutations
{
    public static class LoggerExtensions
    {
        public static IHostBuilder ConfigurationSerilog(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context, logger) =>
            {
                logger.ReadFrom.Configuration(new ConfigurationBuilder()
                        .AddJsonFile("serilog.config.json")
                        .Build())
                    .Enrich.FromLogContext()
                    .CreateLogger();
            });

            return hostBuilder;
        }
    }
}
