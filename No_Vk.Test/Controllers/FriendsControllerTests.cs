using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using No_Vk.Domain.Controllers;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace No_Vk.Test.Controllers
{
    public class FriendsControllerTests
    {
        private Mock<IUserRepository> _mockUserRepository = new();
        private Mock<ILogger<FriendsController>> _mockLogger = new();
        private Mock<IUserDataService> _mockUserData = new();

        [Fact]
        public void AddFriend_EmailNotNullOrEmpty_ReturnDefaultView()
        {
            //Arrange
            FriendsController controller = new(_mockLogger.Object, _mockUserRepository.Object, _mockUserData.Object);
            string email = "";

            //Act 
             ViewResult result = controller.AddFriend(email) as ViewResult;

            //Assert
            Assert.Equal("AddFriend", result?.ViewName);
        }
        [Fact]
        public void AddFriend_IfFriendIsNull_ReturnDefaultView()
        {
            //Arrange
            FriendsController controller = new(_mockLogger.Object, _mockUserRepository.Object, _mockUserData.Object);
            string email = "invalid@email.pain";
            _mockUserRepository.Setup(repo => repo.GetUsers()).Returns(GetTestUsers());
            

            //Act 
            ViewResult result = controller.AddFriend(email) as ViewResult;

            //Assert
            Assert.Equal("AddFriend", result?.ViewName);
        }


        private IQueryable<User> GetTestUsers()
        {
            return new List<User>()
            {
                new("1", "log1", "pass", RoleNames.Base) { Id = "1" },
                new("2", "log2", "pass", RoleNames.Base) { Id = "2" },
                new("3", "log3", "pass", RoleNames.Base) { Id = "3" },
                new("4", "log4", "pass", RoleNames.Base) { Id = "4" },
                new("5", "log5", "pass", RoleNames.Base) { Id = "5" },
                new("6", "log6", "pass", RoleNames.Base) { Id = "6" }

            }.AsQueryable();
        }
    }
}
