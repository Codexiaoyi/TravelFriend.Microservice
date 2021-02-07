using System;
using System.Threading;
using System.Threading.Tasks;

namespace TravelFriend.Infrastructure.Core
{
    /// <summary>
    /// 工作单元模式，持久化数据
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
