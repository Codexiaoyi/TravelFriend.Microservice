using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelFriend.Infrastructure.Core;
using TravelFriend.UserService.Domain.PersonalAggregate;
using TravelFriend.UserService.Domain.TeamAggregate;

namespace TravelFriend.UserService.Infrastructure
{
    public interface IPersonalRepository : IRepository<Personal, Guid>
    {
        /// <summary>
        /// 根据邮箱获取个人信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Personal> GetPersonalByEmailAsync(string email);
        /// <summary>
        /// 获取个人所在团队
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<List<Member>> QueryTeamsAsync(string email);
    }
}
