using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace No_Vk.Domain.Services
{
    public interface IUserDataService
    {
        public User GetMe();
        public Task<User> GetMeAsync();
        public IQueryable<Message> GetMessages();
        public IQueryable<Notice> GetNotices();
    }
}
