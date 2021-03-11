using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TravelFriend.UserService.Domain.PersonalAggregate;

namespace TravelFriend.UserService.UnitTest.Domain
{
    [TestClass]
    public class PersonalAggregateTest
    {
        private Personal person;

        [TestInitialize]
        public void TestInitialize()
        {
            string userName = null;
            Gender gender = default(global::TravelFriend.UserService.Domain.PersonalAggregate.Gender);
            Address address = null;
            string email = "test@email.com";
            string avatar = "";
            Birthday birthday = null;
            person = new Personal(userName, gender, address, email, avatar, birthday);
        }

        [TestMethod]
        public void UpdatePersonalInfo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string userName = "updatePersonalInfo";
            Gender gender = default(global::TravelFriend.UserService.Domain.PersonalAggregate.Gender);
            Address address = null;
            Birthday birthday = null;

            // Act
            person.UpdatePersonalInfo(
                userName,
                gender,
                address,
                birthday);

            // Assert
            Assert.AreEqual(userName, person.UserName);
            Assert.AreEqual(1, person.DomainEvents.Count);
        }

        [TestMethod]
        public void UpdatePersonalAvatar_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string avatar = "newAvatar";

            // Act
            person.UpdatePersonalAvatar(
                avatar);

            // Assert
            Assert.AreEqual(avatar, person.Avatar);
            Assert.AreEqual(1, person.DomainEvents.Count);
        }
    }
}
