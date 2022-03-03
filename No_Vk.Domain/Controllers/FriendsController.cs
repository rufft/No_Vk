using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using System.Text.Json;
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
            string id = "";
            if (string.IsNullOrEmpty(email)) return View("AddFriend");

            User friendUser = _userRepository.GetUsers().FirstOrDefault(u => u.Email == email);

            if (friendUser == null) return View("AddFriend");

            string userJson = HttpContext.Session.GetString("User");
            User user = JsonSerializer.Deserialize<User>(userJson);

            if (user.Id == friendUser.Id) { return View("AddFriend"); }

            Notice notice = new("Запрос на добавление в друзья", friendUser, "", userJson, NoticeType.FriendInvite);
            
            
            IQueryable<Chat> chats = _userRepository.GetUser(id).Chats.AsQueryable();
            
            
            _userRepository.Save();

            return RedirectToAction("Index", "Home");
        }
    }
}
