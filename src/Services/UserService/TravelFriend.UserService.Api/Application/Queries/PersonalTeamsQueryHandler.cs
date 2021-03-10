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
    public class PersonalTeamsQueryHandler : IRequestHandler<PersonalTeamsQuery, List<PersonalTeam>>
    {
        private readonly IPersonalRepository _personalRepository;
        private readonly ITeamRepository _teamRepository;

        public PersonalTeamsQueryHandler(IPersonalRepository personalRepository, ITeamRepository teamRepository)
        {
            _personalRepository = personalRepository;
            _teamRepository = teamRepository;
        }

        public async Task<List<PersonalTeam>> Handle(PersonalTeamsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<PersonalTeam>();
            var teams = await _personalRepository.QueryTeamsAsync(request.Email);
            if (teams == null || teams.Count == 0) return result;

            teams.ForEach(async team =>
            {
                var teamInfo = await _teamRepository.GetAsync(team.TeamId);
                if (teamInfo != null)
                {
                    result.Add(new PersonalTeam()
                    {
                        TeamId = team.TeamId,
                        Name = teamInfo.Name,
                        Avatar = teamInfo.Avatar,
                        Introduction = teamInfo.Introduction,
                        IsLeader = team.IsLeader
                    });
                }
            });

            return result;
        }
    }
}
