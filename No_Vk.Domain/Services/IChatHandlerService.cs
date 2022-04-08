using System.Threading.Tasks;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Services
{
    public interface IChatHandlerService
    {
        public Task CreateChatAsync(ChatBindingTarget chatBindingTarget, params User[] users);
        public Task CreateChatAsync(ChatBindingTarget chatBindingTarget, params string[] usersId);
        public Task CreateMessageAsync(Chat chat, Message message);
    }
}
