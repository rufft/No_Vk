using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Services
{
    public interface IChatHandlerService
    {
        public void CreateChat(ChatBindingTarget chatBindingTarget, params User[] users);
        public void SendMessageToDatabase(Chat chat, Message message);
    }
}
