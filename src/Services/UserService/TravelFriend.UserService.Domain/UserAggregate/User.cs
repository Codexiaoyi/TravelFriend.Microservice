using System;
using System.Collections.Generic;
using System.Text;
using TravelFriend.Domain.Abstractions;

namespace TravelFriend.UserService.Domain.UserAggregate
{
    /// <summary>
    /// 用户聚合的聚合根（用户实体）
    /// </summary>
    public class User : Entity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string UserName { get; private set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; private set; }
        /// <summary>
        /// 住址
        /// </summary>
        public Address Address { get; private set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string Avatar { get; private set; }
        /// <summary>
        /// 生日
        /// </summary>
        public Birthday Birthday { get; private set; }

        protected User() { }
        public User(string userName, Gender gender, Address address, string email, string avatar, Birthday birthday)
        {
            this.Gender = gender;
            this.UserName = userName;
            this.Address = address;
            this.Email = email;
            this.Avatar = avatar;
            this.Birthday = birthday;
        }
    }
}
