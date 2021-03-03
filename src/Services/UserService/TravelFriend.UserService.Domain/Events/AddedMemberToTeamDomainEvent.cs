using System;
using System.Collections.Generic;
using System.Text;
using TravelFriend.Domain.Abstractions;
using TravelFriend.UserService.Domain.TeamAggregate;

namespace TravelFriend.UserService.Domain.Events
{
    public class AddedMemberToTeamDomainEvent : IDomainEvent
    {
        public Member Member { get; private set; }
        public AddedMemberToTeamDomainEvent(Member member)
        {
            this.Member = member;
        }
    }
}
