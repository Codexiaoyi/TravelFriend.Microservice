using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelFriend.UserService.Infrastructure;
using TravelFriend.UserService.Infrastructure.Repositories;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class UpdatePersonalAvatarCommandHandler : IRequestHandler<UpdatePersonalAvatarCommand, bool>
    {
        IPersonalRepository _personalRepository;
        public UpdatePersonalAvatarCommandHandler(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }

        public async Task<bool> Handle(UpdatePersonalAvatarCommand request, CancellationToken cancellationToken)
        {
            var person = await _personalRepository.GetPersonalByEmailAsync(request.Email);
            if (person == null) return false;

            person.UpdatePersonalAvatar(request.Avatar);
            await _personalRepository.UpdateAsync(person);
            return await _personalRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }

    public class UpdateTeamAvatarCommandHandler : IRequestHandler<UpdateTeamAvatarCommand, bool>
    {
        ITeamRepository _teamRepository;
        public UpdateTeamAvatarCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<bool> Handle(UpdateTeamAvatarCommand request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetAsync(request.TeamId);
            if (team == null) return false;

            team.UpdateTeamAvatar(request.Avatar);
            await _teamRepository.UpdateAsync(team);
            return await _teamRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
