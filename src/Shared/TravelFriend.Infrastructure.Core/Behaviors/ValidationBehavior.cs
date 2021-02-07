using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TravelFriend.Infrastructure.Core.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest> _validator;
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

        public ValidationBehavior(IValidator<TRequest> validator, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
        {
            _validator = validator;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var typeName = request.GetGenericTypeName();

            _logger.LogInformation("------开始验证 {TypeName}-------", typeName);

            //验证
            var failures = _validator
                .Validate(request)
                .Errors
                .Where(errors => errors != null)
                .ToList();

            //当存在error时
            if (failures.Any())
            {
                _logger.LogWarning("验证错误 - {TypeName} - 请求类型: {@Request} - Errors: {@ValidationErrors}", typeName, request, failures);

                throw new Exception($"{typeof(TRequest).Name} 验证出现错误！！！", new ValidationException("验证异常", failures));
            }

            return await next();
        }
    }
}
