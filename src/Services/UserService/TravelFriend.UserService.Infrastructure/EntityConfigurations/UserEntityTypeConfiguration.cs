using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelFriend.UserService.Domain.UserAggregate;

namespace GeekTime.Ordering.Infrastructure.EntityConfigurations
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("user");
            builder.Property(p => p.UserName).HasMaxLength(30);
            builder.OwnsOne(o => o.Address, a =>
                {
                    a.WithOwner();
                    a.Property(p => p.City).HasMaxLength(10);
                    a.Property(p => p.Street).HasMaxLength(50);
                    a.Property(p => p.Province).HasMaxLength(20);
                });
            builder.OwnsOne(o => o.Birthday, a =>
            {
                a.WithOwner();
                a.Property(p => p.Year);
                a.Property(p => p.Month);
                a.Property(p => p.Day);
            });
        }
    }
}
