using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Services;

namespace No_Vk.Domain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserDataService _userData;
        private IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserDataService userDataService, IUserRepository userRepository)
        {
            _logger = logger;
            _userData = userDataService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var user = _userData.GetMe();
            return View();
        }
    }
}
