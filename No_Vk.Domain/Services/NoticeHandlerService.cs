using System;
using System.Linq;
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
                var address = _dbContext.Find<User>(addressId);

                address.Friends ??= new();
                notice.Addressee.Friends ??= new();
                
                address.Friends.Add(new(notice.Addressee));
                notice.Addressee.Friends.Add(new(address));

                _dbContext.Notices.Remove(notice);
                _dbContext.SaveChanges();
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
