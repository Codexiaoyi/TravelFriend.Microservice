﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TravelFriend.UserService.Infrastructure;
using TravelFriend.UserService.Domain.UserAggregate;
using TravelFriend.UserService.Api.Application.Behaviors;
using TravelFriend.UserService.Api.Application.Validations;
using FluentValidation;
using TravelFriend.UserService.Api.Application.Commands;

namespace TravelFriend.UserService.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IValidator<RegisterUserCommand>), typeof(RegisterUserCommandValidator));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserCommandValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserContextTransactionBehavior<,>));
            return services.AddMediatR(typeof(User).Assembly, typeof(Program).Assembly);
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
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}