using System;
using System.Collections.Generic;
using System.Text;

namespace TravelFriend.EventBus.IntegrationEvents
{
    public class UserRegisterSucceededIntegrationEvent
    {
        public UserRegisterSucceededIntegrationEvent(string email) => UserEmail = email;

        public string UserEmail { get; }
    }
}
