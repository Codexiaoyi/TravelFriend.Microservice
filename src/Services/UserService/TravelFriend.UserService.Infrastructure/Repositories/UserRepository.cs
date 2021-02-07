
using System;
using TravelFriend.Infrastructure.Core;
using TravelFriend.UserService.Domain.UserAggregate;

namespace TravelFriend.UserService.Infrastructure
{
    public class UserRepository : Repository<User, Guid, UserContext>, IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {
        }
    }
}
