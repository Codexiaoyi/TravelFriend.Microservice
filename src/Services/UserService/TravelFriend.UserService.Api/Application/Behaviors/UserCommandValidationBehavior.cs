using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Infrastructure.Core.Behaviors;

namespace TravelFriend.UserService.Api.Application.Behaviors
{
    public class UserCommandValidationBehavior<TRequest, TResponse> : ValidationBehavior<TRequest, TResponse>
    {
        public UserCommandValidationBehavior(IValidator<TRequest> validator, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
            : base(validator, logger)
        {

        }
    }
}
