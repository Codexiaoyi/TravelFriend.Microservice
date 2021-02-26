using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Common.Http;
using TravelFriend.UserService.Domain.PersonalAggregate;

namespace TravelFriend.UserService.Api.Application.HttpDto
{
    public class PersonalInfoResponseDto : HttpResponse
    {
        public Personal Personal { get; set; }
    }
}
