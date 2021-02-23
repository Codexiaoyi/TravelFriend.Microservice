using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TravelFriend.UserService.Infrastructure;
using TravelFriend.UserService.Domain.PersonalAggregate;
using TravelFriend.UserService.Api.Application.Behaviors;
using TravelFriend.UserService.Api.Application.Validations;
using FluentValidation;
using TravelFriend.UserService.Api.Application.Commands;
using Microsoft.Extensions.Configuration;
using TravelFriend.UserService.Api.Application.IntegrationEvents;
using TravelFriend.EventBus;
using DotNetCore.CAP;

namespace TravelFriend.UserService.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IValidator<UpdatePersonalCommand>), typeof(UpdatePersonalCommandValidator));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PersonalCommandValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserContextTransactionBehavior<,>));
            return services.AddMediatR(typeof(Personal).Assembly, typeof(Program).Assembly);
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICapSubscribe, UserIntegrationEventSubscriber>();
            services.AddCap(options =>
            {
                options.UseEntityFramework<UserContext>();

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
                builder.UseMySql(connectionString, new MySqlServerVersion(new Version()));
            });
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonalRepository, PersonalRepository>();
            return services;
        }
    }
}
