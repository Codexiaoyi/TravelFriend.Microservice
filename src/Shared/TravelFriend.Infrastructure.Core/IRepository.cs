using System.Threading;
using System.Threading.Tasks;
using TravelFriend.Domain.Abstractions;

namespace TravelFriend.Infrastructure.Core
{
    public interface IRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        /// <summary>
        /// 工作单元，数据持久化
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        bool Remove(Entity entity);
        Task<bool> RemoveAsync(Entity entity);
    }


    public interface IRepository<TEntity, TKey> : IRepository<TEntity> where TEntity : Entity<TKey>, IAggregateRoot
    {
        bool Delete(TKey id);
        Task<bool> DeleteAsync(TKey id);
        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id);
    }
}
