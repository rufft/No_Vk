using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using No_Vk.Domain.Services;
using System.Linq;
using System.Text.Json;

namespace No_Vk.Domain.Models.Notices
{
    public class NoticeHeandlerService : INoticeHeandlerService
    {
        private IUserRepository _userRepository;
        private ILogger<NoticeHeandlerService> _logger;
        public NoticeHeandlerService(
            IUserRepository userRepository,
            ILogger<NoticeHeandlerService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public void FriendInviteInvoke(Notice notice, bool isAccepted)
        {
            if (!isAccepted)
            {
                _userRepository.DeleteNotice(notice);
                _userRepository.Save();
                return;
            }

            User user = _userRepository.GetUser(notice.Object);
            Friend friend = new(notice.User, user);

            _userRepository.AddFriend(friend);
            _userRepository.DeleteNotice(notice);
            _userRepository.Save();
        }
        public void ChatInviteInvoke(Notice notice, bool isAccepted)
        {
        }
    }
}
