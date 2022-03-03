using No_Vk.Domain.Models.Data;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models;
using No_Vk.Domain.Controllers;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace No_Vk.Test.Controllers
{
    public class LoginControllerTests
    {
        [Fact]
        public void Registration_EmailShouldBeUnique()
        {
            //Arrange
            UserRegistrationBindingTarget target1 = new() { Email = "1@1.1", Login = "login", Password = "1234"};
            UserRegistrationBindingTarget target2 = new() { Email = "2", Login = "login", Password = "1234"};

            //Act
            User user1 = GetTestUsers().FirstOrDefault(u => u.Email == target1.Email);
            User user2 = GetTestUsers().FirstOrDefault(u => u.Email == target2.Email);

            //Assert
            Assert.Null(user1);
            Assert.NotNull(user2);
        }
        [Fact]
        public void Registration_OnSuccess_RegirectToLoginPage()
        {
            //Arrange
            Mock<IUserRepository> mockUserRepository = new();
            Mock<ILogger<LoginController>> mockLogger = new();
            LoginController controller = new(mockLogger.Object, mockUserRepository.Object);
            UserRegistrationBindingTarget target = new() { Email = "1" };

            //Act
            ViewResult result = controller.Registration(target) as ViewResult;

            //Assert
            Assert.Equal("Login", result?.ViewName);
        }
        [Fact]
        public void Login_EmailShouldMatch()
        {
            //Arrange
            UserLoginBindeingTraget target1 = new() { Email = "1@1.1", Password = "1234" };
            UserLoginBindeingTraget target2 = new() { Email = "2", Password = "1234" };

            //Act
            User user1 = GetTestUsers().FirstOrDefault(u => u.Email == target1.Email);
            User user2 = GetTestUsers().FirstOrDefault(u => u.Email == target2.Email);

            //Assert
            Assert.Null(user1);
            Assert.NotNull(user2);
        }
        [Fact]
        public void Login_PasswordShouldMatch()
        {
            //Arrange
            User user1 = new("1@1.1", "login1", "1234", RoleNames.Base);
            User user2 = new("2@1.1", "login2", "1234", RoleNames.Base);
            User userDb = user1;

            //Act
            bool match1 = user1.Password == userDb.Password;
            bool match2 = user2.Password == userDb.Password;

            //Assert
            Assert.True(match1);
            Assert.False(match2);
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
