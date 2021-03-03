using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelFriend.Common;
using TravelFriend.UserService.Domain.TeamAggregate;
using TravelFriend.UserService.Infrastructure.Repositories;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, bool>
    {
        ITeamRepository _teamRepository;
        public CreateTeamCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<bool> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = new Team(request.Name, string.Empty, TimeHelper.ConvertDataTimeToLong(DateTime.Now), request.Introduction, request.CreatePerson);

            await _teamRepository.AddAsync(team);
            return await _teamRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
