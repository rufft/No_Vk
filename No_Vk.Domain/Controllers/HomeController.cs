using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;
using No_Vk.Domain.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace No_Vk.Domain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserDataService _userData;

        public HomeController(ILogger<HomeController> logger, UserDataService userDataService)
        {
            _logger = logger;
            _userData = userDataService;
        }

        public IActionResult Index()
        {
            _logger.LogInformation(1, HttpContext.Session.GetString("User"));
            var chats = _userData.GetUser().Chats;
            _logger.LogInformation(1, chats.Count().ToString());
            return View();
        }
        public IActionResult Chat() => View();

    }
}
