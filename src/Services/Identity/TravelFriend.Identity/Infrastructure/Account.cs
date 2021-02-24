using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.Identity.Infrastructure
{
    public class Account
    {
        public Account()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
