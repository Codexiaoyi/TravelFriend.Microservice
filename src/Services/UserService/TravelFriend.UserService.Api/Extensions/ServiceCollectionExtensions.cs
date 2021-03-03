using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TravelFriend.UserService.Infrastructure;
using TravelFriend.UserService.Domain.PersonalAggregate;
using FluentValidation;
using TravelFriend.UserService.Api.Application.Commands;
using Microsoft.Extensions.Configuration;
using TravelFriend.UserService.Api.Application.IntegrationEvents;
using TravelFriend.EventBus;
using DotNetCore.CAP;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TravelFriend.UserService.Infrastructure.Repositories;

namespace TravelFriend.UserService.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserContextTransactionBehavior<,>));
            return services.AddMediatR(typeof(Personal).Assembly, typeof(Program).Assembly);
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISubscriberService, SubscriberService>();
            services.AddCap(options =>
            {
                options.UseMySql(configuration.GetValue<string>("Mysql"));

                options.UseRabbitMQ(options =>
                {
                    configuration.GetSection("RabbitMQ").Bind(options);
                });
            });

            return services;
        }

        public static IServiceCollection AddDomainContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            return services.AddDbContext<UserContext>(optionsAction);
        }

        public static IServiceCollection AddMySqlDomainContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDomainContext(builder =>
            {
                builder.UseMySql(connectionString, new MySqlServerVersion(new Version()), b => b.MigrationsAssembly("TravelFriend.UserService.Api"));
            });
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonalRepository, PersonalRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            return services;
        }

        public static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication()
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,//是否验证Issuer
                        ValidateAudience = true,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ClockSkew = TimeSpan.FromSeconds(30),
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = "travelfriend",//Audience
                        ValidIssuer = "travelfriend",//Issuer
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecurityKey"]))//拿到SecurityKey
                    };
                });
            return services;
        }
    }
}
