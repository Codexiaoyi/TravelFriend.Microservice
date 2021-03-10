using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Infrastructure.Core;
using TravelFriend.UserService.Domain.PersonalAggregate;
using TravelFriend.UserService.Domain.TeamAggregate;

namespace TravelFriend.UserService.Infrastructure
{
    public class PersonalRepository : Repository<Personal, Guid, UserContext>, IPersonalRepository
    {
        private readonly UserContext _context;

        public PersonalRepository(UserContext context) : base(context)
        {
            _context = context;
        }

        public Task<Personal> GetPersonalByEmailAsync(string email)
        {
            return _context.Personals.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<List<Member>> QueryTeamsAsync(string email)
        {
            return _context.Members.Where(x => x.Email == email).ToListAsync();
        }
    }
}
