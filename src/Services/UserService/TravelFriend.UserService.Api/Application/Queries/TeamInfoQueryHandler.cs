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
    public class TeamInfoQueryHandler : IRequestHandler<TeamInfoQuery, TeamInfo>
    {
        private readonly ITeamRepository _teamRepository;

        public TeamInfoQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<TeamInfo> Handle(TeamInfoQuery request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetAsync(request.TeamId);
            if (team == null) return null;

            return new TeamInfo()
            {
                TeamId = team.Id,
                Name = team.Name,
                Avatar = team.Avatar,
                CreateTime = team.CreateTime,
                CreatePerson = team.CreatePerson,
                Introduction = team.Introduction
            };
        }
    }
}
