using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
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
        private IUserDataService _userData;
        private IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserDataService userDataService, IUserRepository userRepository)
        {
            _logger = logger;
            _userData = userDataService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
