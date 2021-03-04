using System;
using System.Collections.Generic;
using System.Text;
using TravelFriend.Domain.Abstractions;

namespace TravelFriend.UserService.Domain.Events
{
    public class PersonalAvatarUpdatedDomainEvent : IDomainEvent
    {
        public string Email { get; private set; }
        public string Avatar { get; private set; }
        public PersonalAvatarUpdatedDomainEvent(string email, string avatar)
        {
            this.Email = email;
            this.Avatar = avatar;
        }
    }

    public class TeamAvatarUpdatedDomainEvent : IDomainEvent
    {
        public Guid TeamId { get; private set; }
        public string Avatar { get; private set; }
        public TeamAvatarUpdatedDomainEvent(Guid teamId, string avatar)
        {
            this.TeamId = teamId;
            this.Avatar = avatar;
        }
    }
}
