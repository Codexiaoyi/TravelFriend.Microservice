using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TravelFriend.UserService.Domain.TeamAggregate;

namespace TravelFriend.UserService.UnitTest.Domain
{
    [TestClass]
    public class TeamAggregateTest
    {

        public Team CreateNewTeam()
        {
            string name = "";
            string avatar = "";
            long createTime = 1563349;
            string introduction = "";
            string createPerson = "person@test.com";
            return new Team(name, avatar, createTime, introduction, createPerson);
        }

        [TestMethod]
        public void CreateTeam_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var team = CreateNewTeam();

            // Assert
            Assert.AreEqual(1, team.DomainEvents.Count);
        }

        [TestMethod]
        public void UpdateTeamInfo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var team = CreateNewTeam();
            string name = "newName";
            string intrduction = null;

            // Act
            team.UpdateTeamInfo(
                name,
                intrduction);

            // Assert
            Assert.AreEqual(name, team.Name);
            Assert.AreEqual(2, team.DomainEvents.Count);
        }

        [TestMethod]
        public void UpdateTeamAvatar_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var team = CreateNewTeam();
            string avatar = "testAvatar";

            // Act
            team.UpdateTeamAvatar(
                avatar);

            // Assert
            Assert.AreEqual(avatar, team.Avatar);
            Assert.AreEqual(2, team.DomainEvents.Count);
        }
    }
}
