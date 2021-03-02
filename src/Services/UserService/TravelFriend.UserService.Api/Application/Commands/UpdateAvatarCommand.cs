using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class UpdateAvatarCommand : IRequest<bool>
    {
        public string Email { get; private set; }
        public string Avatar { get; private set; }

        protected UpdateAvatarCommand() { }
        public UpdateAvatarCommand(string email, string avatar)
        {
            this.Email = email;
            this.Avatar = avatar;
        }
    }
}
