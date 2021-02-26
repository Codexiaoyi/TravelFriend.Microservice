using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelFriend.Domain.Abstractions;
using TravelFriend.EventBus.IntegrationEvents;
using TravelFriend.UserService.Domain.Events;

namespace TravelFriend.UserService.Api.Application.DomainEventHandlers
{
    public class PersonalUpdatedDomainEventHandler : IDomainEventHandler<PersonalUpdatedDomainEvent>
    {
        private readonly ICapPublisher _capPublisher;

        public PersonalUpdatedDomainEventHandler(ICapPublisher capPublisher)

        {
            _capPublisher = capPublisher;
        }

        public async Task Handle(PersonalUpdatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _capPublisher.PublishAsync("PersonalUpdated", new PersonalUpdatedInegrationEvent(notification.Personal.Email));
        }
    }
}
