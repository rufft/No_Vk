using Microsoft.AspNetCore.Mvc;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Services;

namespace No_Vk.Domain.Controllers
{
    public class UserController : Controller
    {
        private ILoggedInUserSessionService _loggedInUserSession;
        private IUserRepository _userRepository;

        public UserController(ILoggedInUserSessionService loggedInUserSession, IUserRepository userRepository)
        {
            _loggedInUserSession = loggedInUserSession;
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
