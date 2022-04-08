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
        private readonly UserDbContext _dbContext;
        private readonly ILogger<FriendsController> _logger;
        private readonly IUserDataService _userData;
        public FriendsController(ILogger<FriendsController> logger,
            UserDbContext dbContext,
            IUserDataService userData)
        {
            _dbContext = dbContext;
            _logger = logger;
            _userData = userData;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _userData.GetMe();
            return View(user
                .Friends.Select(f => f.FriendId).ToList());
        }

        [HttpGet]
        public IActionResult AddFriend() => View();

        [HttpPost]
        public IActionResult AddFriend([FromForm] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Validation = "Enter email";
                return View("AddFriend");
            }

            email = email.Trim();
            var friendUser = _dbContext.Users.FirstOrDefault(u => u.Email == email);

            if (friendUser == null)
            {
                ViewBag.Validation = "There is no such user";
                return View("AddFriend");
            }

            if (!HttpContext.Session.Keys.Contains("User"))
            { return RedirectToAction("Login", "Login"); }
            
            
            var me = _userData.GetMe();

            if (User == null)
            { return RedirectToAction("Login", "Login"); }

            if (me?.Id == friendUser.Id)
            {
                ViewBag.Validation = "You are already friends with yourself)";
                return View("AddFriend");
            }

            try
            {
                var notices = _dbContext.Notices;
                if (notices.Any())
                {
                    var addFriendNotice = notices
                        .Where(n => n.Object == me.Id && n.Type == NoticeType.FriendInvite);
                    if (addFriendNotice.Any())
                    {
                        if (addFriendNotice.Select(n => n.Addressee.Id).Contains(friendUser.Id))
                        {
                            ViewBag.Validation = "You have already sent a invite to this person";
                            return View("AddFriend");
                        }
                    }
                }



            }
            catch (Exception e)
            {
                var message = e.Message;
                _logger.LogError("Get notice ERROR: {Message}", message);
                
                ViewBag.Errors = "Server error";
                return View("AddFriend");
            }


            if (me.Friends.FirstOrDefault(f => f.FriendId == friendUser.Id) != null)
            {
                ViewBag.Validation = "This user is already your friend";
                return View("AddFriend");
            }

            Notice notice = new("Friend Invite", friendUser, $"{me.Login} wants to add you as a friend", me.Id, NoticeType.FriendInvite);

            try
            {
                _dbContext.Notices.Add(notice);
            
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                string message = e.Message;
                _logger.LogError("On add notice ERROR: {Message}", message);

                ViewBag.Errors = "Server error";
                return View("AddFriend");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
