using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.ViewModels;
using No_Vk.Domain.Services;

namespace No_Vk.Domain.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatHandlerService _chatHandler;
        private readonly IUserDataService _userData;

        public ChatController(IChatHandlerService chatHandler, IUserDataService userData)
        {
            _chatHandler = chatHandler;
            _userData = userData;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ChatViewModel model)
        {
            List<string> usersId = model.Users
                .Where(d => d.Value)
                .Select(d => d.Key).ToList();
            
            usersId.Add(_userData.GetMe().Id);
            _chatHandler.CreateChat(model.ChatTarget, usersId.ToArray());
            return View("index");
        }
    }
}