using System;
using System.Collections.Generic;
using System.Text;

namespace TravelFriend.EventBus.IntegrationEvents
{
    public class PersonalUpdatedInegrationEvent
    {
        public PersonalUpdatedInegrationEvent(string useremail) => UserEmail = useremail;

        public string UserEmail { get; set; }
    }
}
