using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
            var personal = await _personalRepository.GetPersonalByEmailAsync(request.Email);
            return new Personal()
            {
                UserName = personal.UserName,
                Gender = personal.Gender,
                Province = personal.Address.Province,
                City = personal.Address.City,
                Street = personal.Address.Street,
                Email = personal.Email,
                Avatar = personal.Avatar,
                Year = personal.Birthday.Year,
                Month = personal.Birthday.Month,
                Day = personal.Birthday.Day
            };
        }
    }
}
