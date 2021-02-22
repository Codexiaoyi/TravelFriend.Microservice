using System;
using FluentValidation.Results;
using MediatR;
using TravelFriend.UserService.Api.Application.Validations;
using TravelFriend.UserService.Domain.PersonalAggregate;

namespace TravelFriend.UserService.Api.Application.Commands
{
    public class UpdatePersonalCommand : IRequest<bool>
    {
        public string UserName { get; private set; }

        public Gender Gender { get; private set; }

        public string Province { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }

        public string Email { get; private set; }

        public string Avatar { get; private set; }

        public int Year { get; private set; }

        public int Month { get; private set; }

        public int Day { get; private set; }

        protected UpdatePersonalCommand() { }
        public UpdatePersonalCommand(string userName, Gender gender, string street, string city, string province, string email, string avatar, int year, int month, int day)
        {
            this.Gender = gender;
            this.UserName = userName;
            this.Street = street;
            this.Province = province;
            this.City = city;
            this.Email = email;
            this.Avatar = avatar;
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }
    }
}
