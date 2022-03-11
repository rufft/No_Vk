using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace No_Vk.Domain.Services
{
    public interface IUserDataService
    {
        public User GetMe();
        public IQueryable<Friend> GetFriends();
        public IEnumerable<User> GetFriendsAsUser();
        public IQueryable<Message> GetMessages();
        public IQueryable<Notice> GetNotices();
    }
}
