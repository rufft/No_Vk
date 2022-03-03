using Moq;
using No_Vk.Domain.Controllers;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace No_Vk.Test
{
    public class UserRepositoryTests
    {
        //TODO: Ctreate integration test 


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
