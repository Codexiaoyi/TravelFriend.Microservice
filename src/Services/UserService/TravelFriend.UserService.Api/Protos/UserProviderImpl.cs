using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.UserService.Infrastructure;
using TravelFriend.UserService.Infrastructure.Repositories;

namespace TravelFriend.UserService.Api.Protos
{
    public class UserProviderImpl : UserProvider.UserProviderBase
    {
        private readonly IPersonalRepository _personalRepository;
        private readonly ITeamRepository _teamRepository;

        public UserProviderImpl(IPersonalRepository personalRepository, ITeamRepository teamRepository)
        {
            _personalRepository = personalRepository;
            _teamRepository = teamRepository;
        }

        /// <summary>
        /// 更新个人头像
        /// </summary>
        public async override Task<UpdateResponse> UpdatePersonalAvatar(UpdatePersonalAvatarCommand request, ServerCallContext context)
        {
            var person = await _personalRepository.GetPersonalByEmailAsync(request.Email);
            if (person == null) return new UpdateResponse() { Result = false };

            person.UpdatePersonalAvatar(request.Avatar);
            await _personalRepository.UpdateAsync(person);
            var result = await _personalRepository.UnitOfWork.SaveEntitiesAsync();
            return new UpdateResponse() { Result = result };
        }

        /// <summary>
        /// 更新团队头像
        /// </summary>
        public async override Task<UpdateResponse> UpdateTeamAvatar(UpdateTeamAvatarCommand request, ServerCallContext context)
        {
            var team = await _teamRepository.GetAsync(Guid.Parse(request.TeamId));
            if (team == null) return new UpdateResponse() { Result = false };

            team.UpdateTeamAvatar(request.Avatar);
            await _teamRepository.UpdateAsync(team);
            var result = await _teamRepository.UnitOfWork.SaveEntitiesAsync();
            return new UpdateResponse() { Result = result };
        }
    }
}
