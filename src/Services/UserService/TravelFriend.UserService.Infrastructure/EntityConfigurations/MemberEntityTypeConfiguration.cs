using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TravelFriend.UserService.Domain.TeamAggregate;

namespace TravelFriend.UserService.Infrastructure.EntityConfigurations
{
    class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("team_member");
            builder.Property(p => p.TeamId);
            builder.Property(p => p.Email);
            builder.Property(p => p.IsLeader);
        }
    }
}
