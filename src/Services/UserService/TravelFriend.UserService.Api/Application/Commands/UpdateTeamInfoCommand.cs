using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class UpdateTeamInfoCommand : IRequest<bool>
    {
        public Guid TeamId { get; private set; }

        public string Name { get; private set; }

        public string Introduction { get; private set; }

        protected UpdateTeamInfoCommand() { }
        public UpdateTeamInfoCommand(Guid teamId, string name, string introduction)
        {
            this.TeamId = teamId;
            this.Name = name;
            this.Introduction = introduction;
        }
    }
}
