using Microsoft.AspNetCore.Mvc;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using No_Vk.Domain.Services;

namespace No_Vk.Domain.Controllers
{
    public class UserController : Controller
    {
        private IUserDataService _userData;
        private UserDbContext _dbContext;

        public UserController(IUserDataService userData, UserDbContext dbContext)
        {
            _userData = userData;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm] string userId)
        {
            return View("UserView", userId);
        }
    }
}
