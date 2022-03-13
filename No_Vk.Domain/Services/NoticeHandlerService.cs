using System;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using No_Vk.Domain.Services;
using System.Linq;
using System.Text.Json;

namespace No_Vk.Domain.Models.Notices
{
    public class NoticeHandlerService : INoticeHandlerService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<NoticeHandlerService> _logger;
        public NoticeHandlerService(
            IUserRepository userRepository,
            ILogger<NoticeHandlerService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public void FriendInviteInvoke(Notice notice, bool isAccepted)
        {
            if (notice == null) { return; }
            
            if (!isAccepted)
            {
                try
                {
                    _userRepository.DeleteNotice(notice);
                    _userRepository.Save();
                }
                catch (Exception e)
                {
                    var message = e.Message;
                    _logger.LogError("Friend Invite ERROR: {Message}", message);
                }

                return;
            }

            var address = _userRepository.GetUser(notice.Object);

            if (address == null)
            {
                _logger.LogError("User is Null");
                return;
            }

            try
            {
                var addresseeAsFriend = notice.Addressee.ToFriend();
                var addressAsFriend = address.ToFriend();

                address.Friends.Add(addresseeAsFriend);
                notice.Addressee.Friends.Add(addressAsFriend);

                //_userRepository.DeleteNotice(notice);
                _userRepository.Save();
            }
            catch (Exception e)
            {
                var message = e.Message;
                _logger.LogError("Add Friends ERROR: {Message}", message);
            }

        }
        public void ChatInviteInvoke(Notice notice, bool isAccepted)
        {
        }
    }
}
