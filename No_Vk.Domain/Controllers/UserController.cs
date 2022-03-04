using Microsoft.AspNetCore.Mvc;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Services;

namespace No_Vk.Domain.Controllers
{
    public class UserController : Controller
    {
        private IUserDataService _userData;
        private IUserRepository _userRepository;

        public UserController(IUserDataService userData, IUserRepository userRepository)
        {
            _userData = userData;
            _userRepository = userRepository;
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
