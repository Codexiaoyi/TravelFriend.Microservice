using System;
using TravelFriend.Infrastructure.Core;
using TravelFriend.UserService.Domain.UserAggregate;

namespace TravelFriend.UserService.Infrastructure
{
    public interface IUserRepository : IRepository<User, Guid>
    {

    }
}
