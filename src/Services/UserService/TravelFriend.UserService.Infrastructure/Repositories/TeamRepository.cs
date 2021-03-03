using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelFriend.Infrastructure.Core;
using TravelFriend.UserService.Domain.TeamAggregate;

namespace TravelFriend.UserService.Infrastructure.Repositories
{
    public class TeamRepository : Repository<Team, Guid, UserContext>, ITeamRepository
    {
        private readonly UserContext _context;

        public TeamRepository(UserContext context) : base(context)
        {
            _context = context;
        }

        public Task<Member> AddMemberAsync(Member member)
        {
            return Task.FromResult(_context.Members.Add(member).Entity);
        }
    }
}
