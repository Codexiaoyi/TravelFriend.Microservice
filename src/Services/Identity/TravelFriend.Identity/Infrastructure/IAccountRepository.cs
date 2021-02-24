using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.Identity.Infrastructure
{
    public interface IAccountRepository
    {
        /// <summary>
        /// 添加新账号
        /// </summary>
        Task<bool> AddAccountAsync(Account account);
        /// <summary>
        /// 查询账号
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        Task<Account> QueryAccountAsync(string email);
    }
}
