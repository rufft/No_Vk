using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using No_Vk.Domain.Services;

namespace No_Vk.Domain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserDataService _userData;
        private readonly UserDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, IUserDataService userDataService, UserDbContext dbContext)
        {
            _logger = logger;
            _userData = userDataService;
            _dbContext = dbContext;
        }

        public IActionResult Index()    
        {
            var a = _userData.GetMe();
            return View();
        }
    }
}
