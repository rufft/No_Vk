using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using System.Linq;

namespace No_Vk.Domain.Services
{
    public class ChatHandlerService : IChatHandlerService
    {
        private readonly IUserRepository _userRepository;
        private IUserDataService _userData;
        public ChatHandlerService(IUserRepository userRepository, IUserDataService userData)
        {
            _userRepository = userRepository;
            _userData = userData;
        }

        public void CreateChat(ChatBindingTarget chatBindingTarget, params User[] users)
        {
            Chat chat = chatBindingTarget.ToChat();

            _userRepository.AddChat(chat);

            foreach (var user in users)
            {
                chat.Users?.Add(user);
                
                user.Chats ??= user.Chats = new();
                user.Chats?.Add(chat);
            }
            _userRepository.Save();
        }
        public void CreateChat(ChatBindingTarget chatBindingTarget, params string[] usersId)
        {
            Chat chat = chatBindingTarget.ToChat();

            _userRepository.AddChat(chat);

            foreach (var userId in usersId)
            {
                User user = _userRepository.GetUser(userId);
                chat.Users?.Add(user);
                
                user.Chats ??= user.Chats = new();
                user.Chats?.Add(chat);
            }
            _userRepository.Save();
        }
        public void SendMessageToDatabase(Chat chat, Message message)
        {
            if (message == null || chat == null) return;

            chat.Messages.Add(message);

            _userRepository.UpdateChat(chat);
            _userRepository.Save();
        }
    }
}
