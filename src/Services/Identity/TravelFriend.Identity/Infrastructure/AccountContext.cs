using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.Identity.Infrastructure
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new PersonalEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }

    class PersonalEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account");
            builder.Property(p => p.UserEmail).IsRequired();
            builder.Property(p => p.Password).IsRequired();
        }
    }
}
