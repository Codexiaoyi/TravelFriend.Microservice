using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace TravelFriend.Infrastructure.Core
{
    public interface ITransaction
    {
        /// <summary>
        /// 获取当前事务
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction GetCurrentTransaction();
        /// <summary>
        /// 是否有事务正在执行
        /// </summary>
        bool HasActiveTransaction { get; }
        /// <summary>
        /// 开始事务
        /// </summary>
        /// <returns></returns>
        Task<IDbContextTransaction> BeginTransactionAsync();
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        Task CommitTransactionAsync(IDbContextTransaction transaction);
        /// <summary>
        /// 事务回滚
        /// </summary>
        void RollbackTransaction();
    }
}
