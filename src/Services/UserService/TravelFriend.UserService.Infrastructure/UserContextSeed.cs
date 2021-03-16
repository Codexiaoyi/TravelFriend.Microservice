using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelFriend.UserService.Domain.TeamAggregate;

namespace TravelFriend.UserService.Infrastructure
{
    public class UserContextSeed
    {
        public async Task SeedAsync(UserContext context, ILogger<UserContextSeed> logger)
        {
            using (context)
            {
                logger.LogInformation("开始添加种子数据....");

                context.Database.Migrate();

                if (context.Teams.Count() < 100000)
                {
                    var teams = GenerateTeams(100000 - context.Teams.Count());

                    await context.Teams.AddRangeAsync(teams);

                    await context.SaveChangesAsync();
                }
            }
        }

        public List<Team> GenerateTeams(long count)
        {
            var teams = new List<Team>();
            for (int i = 0; i < count; i++)
            {
                teams.Add(new Team($"name{i}", $"avatar{i}", i, $"introduction{i}", "123@qq.com"));
            }
            return teams;
        }
    }
}
