using System;
using System.Collections.Generic;
using System.Text;
using TravelFriend.Domain.Abstractions;
using TravelFriend.UserService.Domain.TeamAggregate;

namespace TravelFriend.UserService.Domain.Events
{
    public class TeamCreatedDomainEvent : IDomainEvent
    {
        public Team Team { get; private set; }
        public TeamCreatedDomainEvent(Team team)
        {
            this.Team = team;
        }
    }
}
