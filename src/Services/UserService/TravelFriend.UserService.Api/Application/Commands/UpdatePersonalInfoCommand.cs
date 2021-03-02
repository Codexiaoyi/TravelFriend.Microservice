using System;
using FluentValidation.Results;
using MediatR;
using TravelFriend.UserService.Domain.PersonalAggregate;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class UpdatePersonalInfoCommand : IRequest<bool>
    {
        public string UserName { get; private set; }

        public Gender Gender { get; private set; }

        public string Province { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }

        public string Email { get; private set; }

        public int Year { get; private set; }

        public int Month { get; private set; }

        public int Day { get; private set; }

        protected UpdatePersonalInfoCommand() { }
        public UpdatePersonalInfoCommand(string userName, Gender gender, string street, string city, string province, string email, int year, int month, int day)
        {
            this.Gender = gender;
            this.UserName = userName;
            this.Street = street;
            this.Province = province;
            this.City = city;
            this.Email = email;
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }
    }
}
