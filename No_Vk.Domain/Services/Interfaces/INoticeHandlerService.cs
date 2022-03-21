using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Services
{
    public interface INoticeHandlerService
    {
        public void FriendInviteInvoke(Notice notice, bool isAccepted);
        public void ChatInviteInvoke(Notice notice, bool isAccepted);
    }
}
