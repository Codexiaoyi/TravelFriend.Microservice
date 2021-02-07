using GeekTime.Ordering.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelFriend.Infrastructure.Core;
using TravelFriend.UserService.Domain.UserAggregate;

namespace TravelFriend.UserService.Infrastructure
{
    public class UserContext : EFContext
    {
        public UserContext(DbContextOptions options, IMediator mediator) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
