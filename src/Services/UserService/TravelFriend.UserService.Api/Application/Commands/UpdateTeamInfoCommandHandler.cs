using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TravelFriend.UserService.Domain.PersonalAggregate;
using TravelFriend.UserService.Infrastructure;
using TravelFriend.UserService.Infrastructure.Repositories;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class UpdateTeamInfoCommandHandler : IRequestHandler<UpdateTeamInfoCommand, bool>
    {
        ITeamRepository _teamRepository;
        public UpdateTeamInfoCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<bool> Handle(UpdateTeamInfoCommand request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetAsync(request.TeamId);
            if (team == null) return false;

            team.UpdateTeamInfo(request.Name, request.Introduction);
            await _teamRepository.UpdateAsync(team);
            return await _teamRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
