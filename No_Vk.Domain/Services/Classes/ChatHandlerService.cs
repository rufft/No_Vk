using System;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace No_Vk.Domain.Services
{
    public class ChatHandlerService : IChatHandlerService
    {
        private readonly IUserRepository _userRepository;
        private ILoggedInUserSessionService _loggedInUser;
        private readonly ILogger<ChatHandlerService> _logger;

        public ChatHandlerService(
            IUserRepository userRepository,
            ILoggedInUserSessionService loggedInUser,
            ILogger<ChatHandlerService> logger)
        {
            _userRepository = userRepository;
            _loggedInUser = loggedInUser;
            _logger = logger;
        }
        
        public async Task CreateChatAsync(ChatBindingTarget chatBindingTarget, params string[] userIds)
        {
            var chat = chatBindingTarget.ToChat();

            try
            {
                await _userRepository.AddChatAsync(chat);
            }
            catch (Exception e)
            {
                string message = e.Message;
                _logger.LogError("Add Chat to DB ERROR: {Message}", message);
                return;
            }

            foreach (var userId in userIds)
            {
                var user = await _userRepository.GetUserAsync(userId);

                try
                {
                    //TODO: Do Method
                    /*chat.Users.Add(user);
                
                    user.Chats ??= user.Chats = new();
                    user.Chats.Add(chat);*/
                }
                catch (Exception e)
                {
                    string message = e.Message;
                    _logger.LogError("Add users to chat and chat to users ERROR: {Message}", message);
                    return;
                }

            }

            try
            {
                //await _userRepository.SaveAsync();
            }
            catch (Exception e)
            {
                string message = e.Message;
                _logger.LogError("Save DB changes ERROR: {Message}", message);
            }
        }
        
        public async Task AddMessageToDatabaseAsync(Chat chat, Message chatMessage)
        {
            if (chatMessage == null || chat == null) return;

            try
            {
                chat.Messages.Add(chatMessage);

                _userRepository.UpdateChat(chat);
                await _userRepository.SaveAsync();
            }
            catch (Exception e)
            {
                string message = e.Message;
                _logger.LogError("Update Chat ERROR: {Message}", message);
            }
        }
    }
}
