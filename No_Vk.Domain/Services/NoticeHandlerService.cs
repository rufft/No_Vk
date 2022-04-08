using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Services
{
    public class NoticeHandlerService : INoticeHandlerService
    {
        private readonly UserDbContext _dbContext;
        private readonly ILogger<NoticeHandlerService> _logger;
        public NoticeHandlerService(
            ILogger<NoticeHandlerService> logger, UserDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task FriendInviteInvokeAsync(Notice notice, bool isAccepted)
        {
            if (notice == null) { return; }
            
            if (!isAccepted)
            {
                try
                {
                    _dbContext.Notices.Remove(notice);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    var message = e.Message;
                    _logger.LogError("Friend Invite ERROR: {Message}", message);
                }

                return;
            }

            var addressId = notice.Object;
            
            if (string.IsNullOrEmpty(addressId))
            {
                _logger.LogError("My id is Null or empty");
                return;
            }

            try
            {
                var address = await _dbContext.FindAsync<User>(addressId);

                Friend addresseeFriend = new(notice.Addressee.Id, address);
                Friend addressFriend = new(addressId, notice.Addressee);

                
                address.Friends.Add(addressFriend);
                notice.Addressee.Friends.Add(addresseeFriend);

                _dbContext.Notices.Remove(notice);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var message = e.Message;
                _logger.LogError("Add Friends ERROR: {Message}", message);
            }

        }
        public Task ChatInviteInvokeAsync(Notice notice, bool isAccepted)
        {
            throw new NotImplementedException();
        }
    }
}
