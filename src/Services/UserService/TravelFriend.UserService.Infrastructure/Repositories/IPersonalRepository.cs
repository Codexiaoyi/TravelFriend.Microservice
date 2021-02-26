using System;
using System.Threading.Tasks;
using TravelFriend.Infrastructure.Core;
using TravelFriend.UserService.Domain.PersonalAggregate;

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
    }
}
