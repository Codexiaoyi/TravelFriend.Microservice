using Microsoft.Extensions.Logging;
using TravelFriend.Infrastructure.Core;

namespace TravelFriend.UserService.Infrastructure
{
    public class UserContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<UserContext, TRequest, TResponse>
    {
        public UserContextTransactionBehavior(UserContext dbContext, ILogger<UserContextTransactionBehavior<TRequest, TResponse>> logger) : base(dbContext, logger)
        {
        }
    }
}
