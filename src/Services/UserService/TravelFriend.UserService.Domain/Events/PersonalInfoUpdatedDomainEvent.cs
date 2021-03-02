using System;
using System.Collections.Generic;
using System.Text;
using TravelFriend.Domain.Abstractions;
using TravelFriend.UserService.Domain.PersonalAggregate;

namespace TravelFriend.UserService.Domain.Events
{
    public class PersonalInfoUpdatedDomainEvent : IDomainEvent
    {
        public Personal Personal { get; private set; }
        public PersonalInfoUpdatedDomainEvent(Personal personal)
        {
            this.Personal = personal;
        }
    }
}
