using MediatR;

namespace TravelFriend.Domain.Abstractions
{
    /// <summary>
    /// 领域事件处理
    /// </summary>
    /// <typeparam name="TDomainEvent">领域事件</typeparam>
    public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        //INotificationHandler中有默认的Handle方法作为处理的方法
    }
}
