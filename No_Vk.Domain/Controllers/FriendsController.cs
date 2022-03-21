using System;
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
        private readonly IUserRepository _userRepository;
        private readonly ILogger<FriendsController> _logger;
        private readonly ILoggedInUserSessionService _loggedInUserSession;
        public FriendsController(ILogger<FriendsController> logger,
            IUserRepository userRepository,
            ILoggedInUserSessionService loggedInUserSession)
        {
            _userRepository = userRepository;
            _logger = logger;
            _loggedInUserSession = loggedInUserSession;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_loggedInUserSession.Me
                .Friends.Select(f => f.FriendUser).ToList());
        }

        [Route("AddFriend")]
        [HttpGet]
        public IActionResult AddFriend() => View();

        [Route(@"AddFriend")]
        [HttpPost]
        public IActionResult AddFriend([FromForm] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Validation = "Введите почту";
                return View("AddFriend");
            }

            email = email.Trim();
            User friendUser = _userRepository.GetUsers().FirstOrDefault(u => u.Email == email);

            if (friendUser == null)
            {
                ViewBag.Validation = "Такого пользователя нет";
                return View("AddFriend");
            }

            if (!HttpContext.Session.Keys.Contains("Addressee"))
            { return RedirectToAction("Login", "Login"); }
            
            string myId = HttpContext.Session.GetString("Addressee");
            
            if (string.IsNullOrEmpty(myId))
            { return RedirectToAction("Login", "Login"); }
            
            User me = _userRepository.GetUser(myId);

            if (User == null)
            { return RedirectToAction("Login", "Login"); }

            if (me?.Id == friendUser.Id)
            {
                ViewBag.Validation = "Вы уже дружите с собой)";
                return View("AddFriend");
            }

            try
            {
                var addFriendNotice = _userRepository.GetNotices()
                    .Where(n => n.Object == me.Id && n.Type == NoticeType.FriendInvite);
            
                if (addFriendNotice.Select(n => n.Addressee.Id).Contains(friendUser.Id))
                {
                    ViewBag.Validation = "Вы уже отправили запрос этому человеку";
                    return View("AddFriend");
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
                _logger.LogError("Get notice ERROR: {Message}", message);
                
                ViewBag.Errors = "Ошибка сервера";
                return View("AddFriend");
            }


            if (me.Friends.FirstOrDefault(f => f.FriendUser.Id == friendUser.Id) != null)
            {
                ViewBag.Validation = "Этот пользователь уже ваш друг";
                return View("AddFriend");
            }

            Notice notice = new("Запрос на добавление в друзья", friendUser, "", myId, NoticeType.FriendInvite);

            try
            {
                _userRepository.AddNotice(notice);
            
                _userRepository.Save();
            }
            catch (Exception e)
            {
                string message = e.Message;
                _logger.LogError("On add notice ERROR: {Message}", message);

                ViewBag.Errors = "Ошибка сервера";
                return View("AddFriend");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
