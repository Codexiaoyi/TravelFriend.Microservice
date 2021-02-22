using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelFriend.UserService.Domain.PersonalAggregate;

namespace GeekTime.Ordering.Infrastructure.EntityConfigurations
{
    class PersonalEntityTypeConfiguration : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("personal");
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
