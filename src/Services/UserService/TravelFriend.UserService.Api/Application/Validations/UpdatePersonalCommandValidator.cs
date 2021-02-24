using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelFriend.Common;
using TravelFriend.UserService.Api.Application.Commands;

namespace TravelFriend.UserService.Api.Application.Validations
{
    public class UpdatePersonalCommandValidator : AbstractValidator<UpdatePersonalCommand>
    {
        public UpdatePersonalCommandValidator()
        {
            RuleFor(c => c.UserName).NotEmpty().MaximumLength(30);
            RuleFor(c => c.City).MaximumLength(10);
            RuleFor(c => c.Province).MaximumLength(50);
            RuleFor(c => c.Street).MaximumLength(20);
            RuleFor(c => c.Email).NotEmpty().Must(e =>
            {
                return ValidationRules.IsEmail(e);
            }).WithMessage("邮箱格式错误！");
        }
    }
}
