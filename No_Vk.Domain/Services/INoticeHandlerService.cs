using System.Threading.Tasks;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Services
{
    public interface INoticeHandlerService
    {
        public Task FriendInviteInvokeAsync(Notice notice, bool isAccepted);
        public Task ChatInviteInvokeAsync(Notice notice, bool isAccepted);
    }
}
