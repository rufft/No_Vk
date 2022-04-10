using Microsoft.AspNetCore.Http;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace No_Vk.Domain.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserDbContext _dbContext;

        public UserDataService(IHttpContextAccessor httpContextAccessor, UserDbContext userDbContext)
        {
            _httpContextAccessor = httpContextAccessor; 
            _dbContext = userDbContext;
        }

        public User GetMe()
        {
            if (!_httpContextAccessor.HttpContext.Session.Keys.Contains("User")) return null;
            var userId = _httpContextAccessor.HttpContext.Session.GetString("User");
            var user = _dbContext.Users
                .Include(u => u.Friends)
                .Include(u => u.Chats)
                .ThenInclude(c => c.Users).FirstOrDefault(u => u.Id == userId);
            return user;
        }

        public async Task<User> GetMeAsync()
        {
            if (!_httpContextAccessor.HttpContext.Session.Keys.Contains("User")) return null;
            var userId = _httpContextAccessor.HttpContext.Session.GetString("User");
            var user = await _dbContext.Users
                .Include(u => u.Friends)
                .Include(u => u.Chats)
                .ThenInclude(c => c.Users).FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }

        public IQueryable<Message> GetMessages()
        {
            var user = GetMe();
            return user != null ? _dbContext.Messages.Where(m => m.FromUser.Id == user.Id) : null;
        }

        public IQueryable<Notice> GetNotices()
        {
            var user = GetMe();
            return user != null ? _dbContext.Notices.Where(n => n.Addressee.Id == user.Id) : null;
        }

    }
}