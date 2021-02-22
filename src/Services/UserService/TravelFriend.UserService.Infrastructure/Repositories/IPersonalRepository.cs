using System;
using TravelFriend.Infrastructure.Core;
using TravelFriend.UserService.Domain.PersonalAggregate;

namespace TravelFriend.UserService.Infrastructure
{
    public interface IPersonalRepository : IRepository<Personal, Guid>
    {

    }
}
