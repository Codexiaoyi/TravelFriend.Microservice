using DotNetCore.CAP;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelFriend.Infrastructure.Core;
using TravelFriend.UserService.Domain.PersonalAggregate;
using TravelFriend.UserService.Domain.TeamAggregate;
using TravelFriend.UserService.Infrastructure.EntityConfigurations;

namespace TravelFriend.UserService.Infrastructure
{
    public class UserContext : EFContext
    {
        public UserContext(DbContextOptions options, IMediator mediator, ICapPublisher capBus) : base(options, mediator, capBus)
        {
        }

        public DbSet<Personal> Personals { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new PersonalEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TeamEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MemberEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
