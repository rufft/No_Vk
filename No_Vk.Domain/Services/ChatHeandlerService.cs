using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Services
{
    public class ChatHeandlerService : IChatHeandlerService
    {
        private IUserRepository _userRepository;
        public ChatHeandlerService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateChat(ChatBindingTarget chatBindingTarget, params User[] users)
        {
            Chat chat = chatBindingTarget.ToChat();

            _userRepository.AddChat(chat);

            foreach (var user in users)
            {
                user.Chats.Add(chat);
            }

            _userRepository.Save();
        }
    }
}
