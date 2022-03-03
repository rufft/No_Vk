using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;
using No_Vk.Domain.Models.Extensions;
using No_Vk.Domain.Models.Abstractions;

namespace No_Vk.Domain.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private IUserRepository _userRepository;
        public LoginController (ILogger<LoginController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Registration() => View();

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Registration([FromForm] UserRegistrationBindingTarget target)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.GetUsers().FirstOrDefault(u => u.Email == target.Email) == null)
                {
                    _userRepository.AddNewUser(target);
                    return View("Login");
                }
                else
                {
                    return View(target);
                }
            }
            return View(target);
        }
        [HttpPost]
        public IActionResult Login([FromForm] UserLoginBindeingTraget target)
        {
            if (!ModelState.IsValid) { return View(); }

            User user = _userRepository.GetUsers().FirstOrDefault(u => u.Email == target.Email);

            if (user == null) { return View(); }

            if (user.Password != target.Password) { return View(); }

            HttpContext.Session.SetString("User", user.Id);
            
            return RedirectToAction("Index", "Home");
        }
    }
}
