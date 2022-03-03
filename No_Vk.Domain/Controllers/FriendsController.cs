using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using System.Linq;
using No_Vk.Domain.Services;

namespace No_Vk.Domain.Controllers
{
    public class FriendsController : Controller
    {
        private IUserRepository _userRepository;
        private readonly ILogger<FriendsController> _logger;
        private readonly IUserDataService _userData;
        public FriendsController(ILogger<FriendsController> logger,
            IUserRepository userRepository,
            IUserDataService userData)
        {
            _userRepository = userRepository;
            _logger = logger;
            _userData = userData;
        }

        [HttpGet]
        public IActionResult Index() => View(_userData.GetFriendsAsUser());

        [HttpGet]
        public IActionResult AddFriend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFriend([FromForm] string email)
        {
            if (string.IsNullOrEmpty(email)) return View("AddFriend");

            User friendUser = _userRepository.GetUsers().FirstOrDefault(u => u.Email == email);

            if (friendUser == null) return View("AddFriend");

            string userId = HttpContext.Session.GetString("User");
            User user = _userRepository.GetUser(userId);

            if (user.Id == friendUser.Id) { return View("AddFriend"); }

            Notice notice = new("Запрос на добавление в друзья", friendUser, "", userId, NoticeType.FriendInvite);

            _userRepository.AddNotice(notice);
            
            _userRepository.Save();

            return RedirectToAction("Index", "Home");
        }
    }
}
