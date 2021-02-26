using System;
using System.Collections.Generic;
using System.Text;
using TravelFriend.Domain.Abstractions;
using TravelFriend.UserService.Domain.PersonalAggregate;

namespace TravelFriend.UserService.Domain.Events
{
    public class PersonalUpdatedDomainEvent : IDomainEvent
    {
        public Personal Personal { get; private set; }
        public PersonalUpdatedDomainEvent(Personal personal)
        {
            this.Personal = personal;
        }
    }
}
