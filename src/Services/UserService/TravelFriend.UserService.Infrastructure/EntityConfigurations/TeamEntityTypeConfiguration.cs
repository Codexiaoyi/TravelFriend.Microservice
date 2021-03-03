using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TravelFriend.UserService.Domain.TeamAggregate;

namespace TravelFriend.UserService.Infrastructure.EntityConfigurations
{
    class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("team");
            builder.Property(p => p.Name).HasMaxLength(30);
            builder.Property(p => p.Avatar);
            builder.Property(p => p.CreateTime);
            builder.Property(p => p.Introduction);
        }
    }
}
