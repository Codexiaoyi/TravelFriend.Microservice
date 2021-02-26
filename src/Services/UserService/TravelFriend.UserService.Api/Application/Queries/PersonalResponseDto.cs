using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Common.Http;
using TravelFriend.UserService.Domain.PersonalAggregate;

namespace TravelFriend.UserService.Api.Application.Queries
{
    public class PersonalInfoResponseDto : HttpResponse
    {
        public Personal Personal { get; set; }
    }

    public record Personal
    {
        public string UserName { get; init; }
        public Gender Gender { get; init; }
        public string Province { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string Email { get; init; }
        public string Avatar { get; init; }
        public int Year { get; init; }
        public int Month { get; init; }
        public int Day { get; init; }
    }
}
