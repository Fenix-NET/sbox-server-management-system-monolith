
using Microsoft.Extensions.DependencyInjection;
using SboxServersManager.Api.Extensions;
using SboxServersManager.Application;
using SboxServersManager.Infrastructure;
using SboxServersManager.Infrastructure.Logging.Configutations;
using Serilog;

namespace SboxServersManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                var builder = WebApplication.CreateBuilder(args);

                builder.Host.ConfigurationSerilog();

                builder.Services.ConfigurationCors();
                builder.Services.ConfigureVersioning();

                builder.Services.AddApplication();
                builder.Services.AddInfrastructure(builder.Configuration);

                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                var app = builder.Build();

                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthentication();
                app.UseAuthorization();

                app.UseSerilogRequestLogging();

                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "server terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
