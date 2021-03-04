using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class UpdatePersonalAvatarCommand : IRequest<bool>
    {
        public string Email { get; private set; }
        public string Avatar { get; private set; }

        protected UpdatePersonalAvatarCommand() { }
        public UpdatePersonalAvatarCommand(string email, string avatar)
        {
            this.Email = email;
            this.Avatar = avatar;
        }
    }

    public class UpdateTeamAvatarCommand : IRequest<bool>
    {
        public Guid TeamId { get; private set; }
        public string Avatar { get; private set; }

        protected UpdateTeamAvatarCommand() { }
        public UpdateTeamAvatarCommand(Guid teamId, string avatar)
        {
            this.TeamId = teamId;
            this.Avatar = avatar;
        }
    }
}
