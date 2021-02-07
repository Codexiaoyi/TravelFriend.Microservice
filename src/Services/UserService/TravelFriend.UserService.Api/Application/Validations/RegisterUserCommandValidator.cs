using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelFriend.UserService.Api.Application.Commands;

namespace TravelFriend.UserService.Api.Application.Validations
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(c => c.UserName).NotEmpty().MaximumLength(30);
            RuleFor(c => c.City).MaximumLength(10);
            RuleFor(c => c.Province).MaximumLength(50);
            RuleFor(c => c.Street).MaximumLength(20);
            RuleFor(c => c.Email).NotEmpty().Must(e =>
            {
                if (string.IsNullOrEmpty(e)) return false;
                Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
                Match m = RegEmail.Match(e);
                return m.Success;
            }).WithMessage("邮箱格式错误！");
        }
    }
}
