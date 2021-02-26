using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelFriend.UserService.Domain.PersonalAggregate;
using TravelFriend.UserService.Infrastructure;

namespace TravelFriend.UserService.Api.Application.Queries
{
    public class PersonalInfoQueryHandler : IRequestHandler<PersonalInfoQuery, Personal>
    {
        private readonly IPersonalRepository _personalRepository;

        public PersonalInfoQueryHandler(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }

        public async Task<Personal> Handle(PersonalInfoQuery request, CancellationToken cancellationToken)
        {
            return await _personalRepository.GetPersonalByEmailAsync(request.Email);
        }
    }
}
