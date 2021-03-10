using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.UserService.Api.Application.Queries
{
    public class PersonalTeamsQuery : IRequest<List<PersonalTeam>>
    {
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }
    }
}
