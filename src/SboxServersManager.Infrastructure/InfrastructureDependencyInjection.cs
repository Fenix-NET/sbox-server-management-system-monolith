using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Infrastructure.Data;
using SboxServersManager.Infrastructure.Data.Repositories;
using SboxServersManager.Infrastructure.Identity.Entities;
using System.Text;

namespace SboxServersManager.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Регистрирация и настройка поставщиков БД ************************************
            services.AddDbContext<ServersManagerDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ServersManagerContext")));
            
            //Регистрация сервисов ************************************
            services.AddScoped<IServerRepository, ServerRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IModRepository, ModRepository>();

            //Регистрация и настройка сервисов Аутентификации и Авторизации ************************************
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;

                options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

            })
                .AddEntityFrameworkStores<ServersManagerDbContext>()
                .AddDefaultTokenProviders();

            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidAudience = jwtSettings["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });


            return services;
        }
    }
}
