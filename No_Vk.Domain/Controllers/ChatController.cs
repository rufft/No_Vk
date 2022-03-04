using Microsoft.AspNetCore.Mvc;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace No_Vk.Domain.Controllers
{
    public class ChatController : Controller
    {
        private IUserDataService _userData;
        private IUserRepository _userRepository;
        public ChatController(IUserDataService userData, IUserRepository userRepository)
        {
            _userData = userData;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View(_userData.GetUser().Chats as List<Chat>);
        }

        [HttpPost]
        public IActionResult Index(string userId)
        {
            User user = _userRepository.GetUser(userId);
            User user2 = _userData.GetUser();
            Chat chat = new("TestChat");

            //_userRepository.AddChat(chat);
            user.Chats.Add(chat);
            user2.Chats.Add(chat);

            _userRepository.Save();
            return View("Chat", chat);
        }
    }
}
