using System;
using System.Collections.Generic;
using System.Text;
using TravelFriend.Domain.Abstractions;
using TravelFriend.UserService.Domain.TeamAggregate;

namespace TravelFriend.UserService.Domain.Events
{
    public class TeamInfoUpdatedDomainEvent : IDomainEvent
    {
        public Team Team { get; private set; }
        public TeamInfoUpdatedDomainEvent(Team personal)
        {
            this.Team = personal;
        }
    }
}
