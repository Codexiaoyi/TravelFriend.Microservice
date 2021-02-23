using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.EventBus;
using TravelFriend.EventBus.IntegrationEvents;

namespace TravelFriend.UserService.Api.Application.IntegrationEvents
{
    public class UserIntegrationEventSubscriber : ICapSubscribe
    {
        [CapSubscribe("UserRegisterSucceeded")]
        public void UserRegisterSucceeded(object @event)
        {
            //用户注册成功，添加新用户数据
        }
    }
}
