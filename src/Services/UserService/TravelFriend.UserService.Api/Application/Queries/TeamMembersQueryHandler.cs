using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelFriend.UserService.Infrastructure;
using TravelFriend.UserService.Infrastructure.Repositories;

namespace TravelFriend.UserService.Api.Application.Queries
{
    public class TeamMembersQueryHandler : IRequestHandler<TeamMembersQuery, List<TeamMember>>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPersonalRepository _personalRepository;

        public TeamMembersQueryHandler(ITeamRepository teamRepository, IPersonalRepository personalRepository)
        {
            _teamRepository = teamRepository;
            _personalRepository = personalRepository;
        }

        public async Task<List<TeamMember>> Handle(TeamMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _teamRepository.QueryMembersAsync(request.TeamId);
            var result = new List<TeamMember>();
            members.ForEach(async m =>
            {
                var peroson = await _personalRepository.GetPersonalByEmailAsync(m.Email);
                result.Add(new TeamMember()
                {
                    TeamId = m.TeamId,
                    Email = m.Email,
                    Name = peroson.UserName,
                    Avatar = peroson.Avatar,
                    IsLeader = m.IsLeader
                });
            });
            return result;
        }
    }
}
