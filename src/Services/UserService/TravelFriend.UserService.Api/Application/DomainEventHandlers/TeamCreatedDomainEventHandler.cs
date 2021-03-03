using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelFriend.Domain.Abstractions;
using TravelFriend.UserService.Domain.Events;
using TravelFriend.UserService.Domain.TeamAggregate;
using TravelFriend.UserService.Infrastructure.Repositories;

namespace TravelFriend.UserService.Api.Application.DomainEventHandlers
{
    public class TeamCreatedDomainEventHandler : IDomainEventHandler<TeamCreatedDomainEvent>
    {
        private readonly ITeamRepository _teamRepository;

        public TeamCreatedDomainEventHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task Handle(TeamCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var member = new Member(notification.Team.Id, notification.Team.CreatePerson, true);
            //新的团队需要增加初始成员
            await _teamRepository.AddMemberAsync(member);
            await _teamRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
