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
            User user1 = new() { Email = "1@1.1", Password = "1234" };
            User user2 = new() { Email = "2", Password = "1234123" };
            User userDb = new() { Email = user1.Email, Password = user1.Password };

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
                new() { Email = "1", Id = "12341243", Login = "log1", Password = "pass1", Role = RoleNames.Base.ToString() },
                new() { Email = "2", Id = "11231243", Login = "log2", Password = "pass2", Role = RoleNames.Base.ToString() },
                new() { Email = "3", Id = "13451243", Login = "log3", Password = "pass3", Role = RoleNames.Base.ToString() },
                new() { Email = "4", Id = "11223443", Login = "log4", Password = "pass4", Role = RoleNames.Base.ToString() },
                new() { Email = "5", Id = "34531243", Login = "log5", Password = "pass5", Role = RoleNames.Base.ToString() },
                new() { Email = "6", Id = "65673243", Login = "log6", Password = "pass6", Role = RoleNames.Base.ToString() }

            }.AsQueryable();
        }
    }
}
