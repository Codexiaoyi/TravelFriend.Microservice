using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Domain.Abstractions;

namespace TravelFriend.Infrastructure.Core.Extensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext ctx)
        {
            //获取当前上下文中所有有领域事件的实体
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            //获取所有的领域事件
            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            //先将领域事件列表清空
            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            //发布对应的领域事件
            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
