using System.Threading.Tasks;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Services
{
    public interface IChatHandlerService
    {
        public Task CreateChatAsync(ChatBindingTarget chatBindingTarget, params string[] userIds);
        public Task AddMessageToDatabaseAsync(Chat chat, Message chatMessage);
    }
}
