using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TravelFriend.UserService.Domain.UserAggregate;
using TravelFriend.UserService.Infrastructure;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        IUserRepository _userRepository;
        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Street, request.City, request.Province);
            var birthday = new Birthday(request.Year, request.Month, request.Day);
            var user = new User(request.UserName, request.Gender, address, request.Email, request.Avatar, birthday);

            _userRepository.Add(user);
            await _userRepository.UnitOfWork.SaveEntitiesAsync();
            return user.Id;
        }
    }
}
