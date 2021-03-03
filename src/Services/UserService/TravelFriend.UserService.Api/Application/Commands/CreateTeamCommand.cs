using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class CreateTeamCommand : IRequest<bool>
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatePerson { get; private set; }
        /// <summary>
        /// 团队名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 团队简介
        /// </summary>
        public string Introduction { get; private set; }

        protected CreateTeamCommand() { }
        public CreateTeamCommand(string createPerson,string name, string introduction)
        {
            this.CreatePerson = createPerson;
            this.Name = name;
            this.Introduction = introduction;
        }
    }
}
