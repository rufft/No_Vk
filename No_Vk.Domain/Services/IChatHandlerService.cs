using System.Threading.Tasks;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Services
{
    public interface IChatHandlerService
    {
        public void CreateChat(ChatBindingTarget chatBindingTarget, params string[] userIds);
        public void CreateMessage(Chat chat, Message message);
    }
}
