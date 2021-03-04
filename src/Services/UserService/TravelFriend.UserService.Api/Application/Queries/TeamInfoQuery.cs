using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.UserService.Api.Application.Queries
{
    public class TeamInfoQuery : IRequest<TeamInfo>
    {
        /// <summary>
        /// 团队Id
        /// </summary>
        public Guid TeamId { get; set; }
    }
}
