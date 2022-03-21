using System;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Extensions;

namespace No_Vk.Domain.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserRepository _userRepository;
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
            if (!ModelState.IsValid) return View(target);

            target.Email = target.Email.Trim();
            target.Login = target.Login.Trim();
            target.Password = target.Password.Trim();

            if (_userRepository.GetUsers().FirstOrDefault(u => u.Email == target.Email) != null)
            {
                ViewBag.Validation = "Пользователь с такой почтой уже существует";
                return View(target);
            }

            try
            {
                _userRepository.AddUser(target);
                _userRepository.Save();
            }
            catch (Exception e)
            {
                string message = e.Message;
                _logger.LogError("Create new user ERROR: {Message}", message);
                return View(target);
            }

            return View("Login");
        }
        [HttpPost]
        public IActionResult Login([FromForm] UserLoginBindingTarget target)
        {
            if (!ModelState.IsValid) { return View(); }

            target.Email = target.Email.Trim();
            target.Password = target.Password.Trim();
            
            var users = _userRepository.GetUsers();
            User user = users.FirstOrDefault(u => u.Email == target.Email);

            if (user == null)
            {
                ViewBag.Validation = "Вы неправильно ввели логин или пароль";
                return View();
            }

            if (user.Password != target.Password)
            {
                ViewBag.Validation = "Вы неправильно ввели логин или пароль";
                return View();
            }

            try
            {
                HttpContext.Session.SetObject("User", user.ToSessionUser());
            }
            catch (Exception e)
            {
                string message = e.Message;
                _logger.LogError("Set SessionUser to session ERROR: {Message}", message);
                return View();
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}
