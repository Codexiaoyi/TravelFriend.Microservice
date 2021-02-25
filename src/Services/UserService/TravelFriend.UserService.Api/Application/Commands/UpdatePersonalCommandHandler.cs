using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TravelFriend.UserService.Domain.PersonalAggregate;
using TravelFriend.UserService.Infrastructure;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class UpdatePersonalCommandHandler : IRequestHandler<UpdatePersonalCommand, bool>
    {
        IPersonalRepository _personalRepository;
        public UpdatePersonalCommandHandler(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }

        public async Task<bool> Handle(UpdatePersonalCommand request, CancellationToken cancellationToken)
        {
            var person = await _personalRepository.GetPersonalByEmail(request.Email);
            var address = new Address(request.Street, request.City, request.Province);
            var birthday = new Birthday(request.Year, request.Month, request.Day);

            person.UpdatePersonal(request.UserName, request.Gender, address, request.Avatar, birthday);
            await _personalRepository.UpdateAsync(person);
            return await _personalRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
