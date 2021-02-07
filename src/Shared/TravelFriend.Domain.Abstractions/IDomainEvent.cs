using MediatR;

namespace TravelFriend.Domain.Abstractions
{
    /// <summary>
    /// 领域事件
    /// </summary>
    public interface IDomainEvent : INotification
    {
    }
}
