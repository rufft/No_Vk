using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models.ViewModels;
using No_Vk.Domain.Services;

namespace No_Vk.Domain.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatHandlerService _chatHandler;
        private readonly IUserDataService _userData;
        private readonly ILogger<ChatController> _logger;

        public ChatController(IChatHandlerService chatHandler, IUserDataService userData, ILogger<ChatController> logger)
        {
            _chatHandler = chatHandler;
            _userData = userData;
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ChatViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            
            if (model == null)
            {
                _logger.LogError("ChatViewModel model is Null ERROR");
                return View();
            }

            if (!model.UserIds.Any())
            {
                ViewBag.Validation = "Need to add friends to the chat";
                return View();
            }
            
            var userIds = model.UserIds
                .Where(d => d.Value)
                .Select(d => d.Key).ToList();
            
            userIds.Add(_userData.GetMe().Id);
            _chatHandler.CreateChatAsync(model.ChatTarget, userIds.ToArray());
            return RedirectToAction("Index", "Home");
        }
    }
}