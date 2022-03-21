using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Services;

namespace No_Vk.Domain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoggedInUserSessionService _loggedInUserSession;
        private IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, ILoggedInUserSessionService loggedInUserSessionService, IUserRepository userRepository)
        {
            _logger = logger;
            _loggedInUserSession = loggedInUserSessionService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            //_loggedInUserData.I++;
            return View();
        }
    }
}
