using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelFriend.UserService.Infrastructure;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class UpdateAvatarCommandHandler : IRequestHandler<UpdateAvatarCommand, bool>
    {
        IPersonalRepository _personalRepository;
        public UpdateAvatarCommandHandler(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }

        public async Task<bool> Handle(UpdateAvatarCommand request, CancellationToken cancellationToken)
        {
            var person = await _personalRepository.GetPersonalByEmailAsync(request.Email);
            if (person == null) return false;

            person.UpdatePersonalAvatar(request.Avatar);
            await _personalRepository.UpdateAsync(person);
            return await _personalRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
