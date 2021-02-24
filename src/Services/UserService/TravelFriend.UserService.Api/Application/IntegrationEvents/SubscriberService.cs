using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.EventBus;
using TravelFriend.EventBus.IntegrationEvents;
using TravelFriend.UserService.Domain.PersonalAggregate;
using TravelFriend.UserService.Infrastructure;

namespace TravelFriend.UserService.Api.Application.IntegrationEvents
{
    public class SubscriberService : ICapSubscribe, ISubscriberService
    {
        private readonly IPersonalRepository _personalRepository;

        public SubscriberService(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }

        [CapSubscribe("UserRegisterSucceeded")]
        public async Task UserRegisterSucceeded(UserRegisterSucceededIntegrationEvent @event)
        {
            //用户注册成功，添加新用户数据
            var user = new Personal(Guid.NewGuid().ToString().Split('-').LastOrDefault().ToUpper(), Gender.Female, new Address(), @event.UserEmail, string.Empty, new Birthday());

            _personalRepository.Add(user);
            await _personalRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
