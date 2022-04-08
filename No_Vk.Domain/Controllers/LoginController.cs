using System;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;
using No_Vk.Domain.Models.Abstractions;

namespace No_Vk.Domain.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly UserDbContext _dbContext;
        public LoginController (ILogger<LoginController> logger, UserDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Registration() => View();

        [HttpGet]
        public IActionResult Login() => View();

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Registration([FromForm] UserRegistrationBindingTarget target)
        {
            if (!ModelState.IsValid) return View(target);

            target.Email = target.Email.Trim();
            target.Login = target.Login.Trim();
            target.Password = target.Password.Trim();
            
            if (_dbContext.Users.FirstOrDefault(u => u.Email == target.Email) != null)
            {
                ModelState["Email"].Errors
                    .Add("A User with this email already exists");
                return View(target);
            }

            try
            {
                _dbContext.Users.Add(target.ToUser());
                _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var message = e.Message;
                _logger.LogError("Create new user ERROR: {Message}", message);
                ViewBag.Error = "Server Error";
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
            
            var users = _dbContext.Users;

            if (!users.Any())
            {
                ModelState.AddModelError(string.Empty,"You entered the incorrect username or password");
                return View();
            }
            
            var user = users.FirstOrDefault(u => u.Email == target.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty,"You entered the incorrect username or password");
                return View();
            }

            if (user.Password != target.Password)
            {
                ModelState.AddModelError(string.Empty,"You entered the incorrect username or password");
                return View();
            }

            try
            {
                HttpContext.Session.SetString("User", user.Id);
            }
            catch (Exception e)
            {
                var message = e.Message;
                _logger.LogError("Set string User to session ERROR: {Message}", message);
                ViewBag.Error = "Server Error";
                return View();
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}
