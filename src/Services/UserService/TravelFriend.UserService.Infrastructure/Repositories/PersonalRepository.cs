
using System;
using TravelFriend.Infrastructure.Core;
using TravelFriend.UserService.Domain.PersonalAggregate;

namespace TravelFriend.UserService.Infrastructure
{
    public class PersonalRepository : Repository<Personal, Guid, UserContext>, IPersonalRepository
    {
        public PersonalRepository(UserContext context) : base(context)
        {
        }
    }
}
