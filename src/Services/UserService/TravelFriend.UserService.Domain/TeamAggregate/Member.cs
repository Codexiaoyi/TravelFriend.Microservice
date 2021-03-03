using System;
using System.Collections.Generic;
using System.Text;
using TravelFriend.Domain.Abstractions;
using TravelFriend.UserService.Domain.Events;

namespace TravelFriend.UserService.Domain.TeamAggregate
{
    /// <summary>
    /// 团队成员实体
    /// </summary>
    public class Member : Entity<Guid>
    {
        /// <summary>
        /// 所属团队Id
        /// </summary>
        public Guid TeamId { get; private set; }
        /// <summary>
        /// 成员邮箱
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// 是否为队长
        /// </summary>
        public bool IsLeader { get; private set; }

        protected Member() { }
        public Member(Guid teamId, string email, bool isLeader)
        {
            this.TeamId = teamId;
            this.Email = email;
            this.IsLeader = isLeader;

            this.AddDomainEvent(new AddedMemberToTeamDomainEvent(this));
        }
    }
}
