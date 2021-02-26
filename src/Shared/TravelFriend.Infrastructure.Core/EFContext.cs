using DotNetCore.CAP;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelFriend.Infrastructure.Core.Extensions;

namespace TravelFriend.Infrastructure.Core
{
    public class EFContext : DbContext, IUnitOfWork, ITransaction
    {
        protected IMediator _mediator;
        ICapPublisher _capBus;

        public EFContext(DbContextOptions options, IMediator mediator, ICapPublisher capBus) : base(options)
        {
            _mediator = mediator;
            _capBus = capBus;
        }

        #region ITransaction
        private IDbContextTransaction _currentContextTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentContextTransaction;
        public bool HasActiveTransaction => _currentContextTransaction != null;

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (HasActiveTransaction) return null;
            _currentContextTransaction = Database.BeginTransaction(_capBus, autoCommit: false);
            return Task.FromResult(_currentContextTransaction);
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentContextTransaction) throw new InvalidOperationException($"{transaction.TransactionId} is not current transaction");

            try
            {
                //保险起见，保证更改已保存
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                //提交事务异常，直接回滚
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentContextTransaction != null)
                {
                    _currentContextTransaction.Dispose();
                    _currentContextTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentContextTransaction?.Rollback();
            }
            finally
            {
                if (_currentContextTransaction != null)
                {
                    _currentContextTransaction.Dispose();
                    _currentContextTransaction = null;
                }
            }
        }
        #endregion

        #region IUnitOfWork
        /// <summary>
        /// 数据持久化
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken) > 0;
            if (result) await _mediator.DispatchDomainEventsAsync(this);
            return result;
        }
        #endregion
    }
}
