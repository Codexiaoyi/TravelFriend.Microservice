using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Common.Http;

namespace TravelFriend.UserService.Api.Application.Queries
{
    public class TeamInfoResponseDto : HttpResponse
    {
        public TeamInfo Team { get; set; }
    }

    public class TeamMemberResponseDto : HttpResponse
    {
        public List<TeamMember> Members { get; set; }
    }

    public record TeamInfo
    {
        public Guid TeamId { get; init; }
        public string Name { get; init; }
        public string Avatar { get; init; }
        public long CreateTime { get; init; }
        public string CreatePerson { get; init; }
        public string Introduction { get; init; }
    }

    public record TeamMember
    {
        public Guid TeamId { get; init; }
        public string Email { get; init; }
        public string Name { get; init; }
        public string Avatar { get; init; }
        public bool IsLeader { get; init; }
    }
}
