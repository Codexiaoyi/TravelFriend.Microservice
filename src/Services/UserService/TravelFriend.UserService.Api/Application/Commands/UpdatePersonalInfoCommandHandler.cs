using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TravelFriend.UserService.Domain.PersonalAggregate;
using TravelFriend.UserService.Infrastructure;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class UpdatePersonalInfoCommandHandler : IRequestHandler<UpdatePersonalInfoCommand, bool>
    {
        IPersonalRepository _personalRepository;
        public UpdatePersonalInfoCommandHandler(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }

        public async Task<bool> Handle(UpdatePersonalInfoCommand request, CancellationToken cancellationToken)
        {
            var person = await _personalRepository.GetPersonalByEmailAsync(request.Email);
            if (person == null) return false;
            var address = new Address(request.Street, request.City, request.Province);
            var birthday = new Birthday(request.Year, request.Month, request.Day);

            person.UpdatePersonalInfo(request.UserName, request.Gender, address, birthday);
            await _personalRepository.UpdateAsync(person);
            return await _personalRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
