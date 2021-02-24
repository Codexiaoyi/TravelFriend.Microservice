using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.EventBus.IntegrationEvents;

namespace TravelFriend.UserService.Api.Application.IntegrationEvents
{
    public interface ISubscriberService
    {
        void UserRegisterSucceeded(UserRegisterSucceededIntegrationEvent @event);
    }
}
