﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelFriend.Infrastructure.Core;
using TravelFriend.UserService.Domain.TeamAggregate;

namespace TravelFriend.UserService.Infrastructure.Repositories
{
    public interface ITeamRepository : IRepository<Team, Guid>
    {
        /// <summary>
        /// 添加一个新成员
        /// </summary>
        /// <param name="member">成员</param>
        /// <returns></returns>
        Task<Member> AddMemberAsync(Member member);
    }
}
