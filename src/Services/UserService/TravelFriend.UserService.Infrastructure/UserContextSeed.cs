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
        const long MAX_ITEMS = 1000000;

        public async Task SeedAsync(UserContext context, ILogger<UserContextSeed> logger)
        {
            using (context)
            {
                logger.LogInformation("开始添加种子数据....");

                context.Database.Migrate();

                var total = context.Teams.Count();
                if (total < MAX_ITEMS)
                {
                    var persons = context.Personals.ToList();
                    var teams = new List<Team>();
                    foreach (var person in persons)
                    {
                        teams.AddRange(GenerateTeams((MAX_ITEMS - total) / persons.Count, person.Email));
                    }

                    await context.Teams.AddRangeAsync(teams);
                    await context.SaveChangesAsync();
                }
            }
        }

        public List<Team> GenerateTeams(long count, string create)
        {
            var teams = new List<Team>();
            for (int i = 0; i < count; i++)
            {
                teams.Add(new Team($"name{Guid.NewGuid().ToString().Substring(30, 6)}", $"avatar{Guid.NewGuid().ToString().Substring(30, 6)}", i, $"introduction{Guid.NewGuid().ToString().Substring(30, 6)}", create));
            }
            return teams;
        }
    }
}
