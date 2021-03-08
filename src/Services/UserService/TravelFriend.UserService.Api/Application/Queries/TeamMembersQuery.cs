using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.UserService.Api.Application.Queries
{
    public class TeamMembersQuery : IRequest<List<TeamMember>>
    {
        /// <summary>
        /// 团队Id
        /// </summary>
        public Guid TeamId { get; set; }
    }
}
