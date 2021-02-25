using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Common.Http;

namespace TravelFriend.Identity.HttpDto
{
    public class AccountResponseDto : HttpResponse
    {
        public string Token { get; set; }
    }
}
