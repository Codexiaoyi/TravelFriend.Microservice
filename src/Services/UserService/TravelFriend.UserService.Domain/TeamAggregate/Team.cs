using System;
using System.Collections.Generic;
using System.Text;
using TravelFriend.Domain.Abstractions;
using TravelFriend.UserService.Domain.Events;

namespace TravelFriend.UserService.Domain.TeamAggregate
{
    /// <summary>
    /// 团队聚合的聚合根（团队实体）
    /// </summary>
    public class Team : Entity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// 团队名
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string Avatar { get; private set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public long CreateTime { get; private set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatePerson { get; private set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string Introduction { get; private set; }

        protected Team() { }
        public Team(string name, string avatar, long createTime, string introduction, string createPerson)
        {
            this.Name = name;
            this.Avatar = avatar;
            this.CreateTime = createTime;
            this.Introduction = introduction;
            this.CreatePerson = createPerson;

            this.AddDomainEvent(new TeamCreatedDomainEvent(this));
        }

        /// <summary>
        /// 更新团队信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="gender">性别</param>
        public void UpdateTeamInfo(string name, string intrduction)
        {
            this.Name = name;
            this.Introduction = intrduction;

            this.AddDomainEvent(new TeamInfoUpdatedDomainEvent(this));
        }

        /// <summary>
        /// 更新用户团队头像地址
        /// </summary>
        /// <param name="avatar">住址</param>
        public void UpdateTeamAvatar(string avatar)
        {
            this.Avatar = avatar;

            this.AddDomainEvent(new TeamAvatarUpdatedDomainEvent(this.Id, this.Avatar));
        }
    }
}