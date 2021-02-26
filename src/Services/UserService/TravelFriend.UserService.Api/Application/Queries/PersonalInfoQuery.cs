using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.UserService.Domain.PersonalAggregate;

namespace TravelFriend.UserService.Api.Application.Queries
{
    public class PersonalInfoQuery : IRequest<Personal>
    {
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }
    }
}
