using Microsoft.AspNetCore.Http;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;
using System.Linq;
using System.Threading.Tasks;

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
            var user = _dbContext.Find<User>(_httpContextAccessor.HttpContext.Session.GetString("User"));
            return user;
        }

        public async Task<User> GetMeAsync()
        {
            if (!_httpContextAccessor.HttpContext.Session.Keys.Contains("User")) return null;
            var user = await _dbContext.FindAsync<User>(_httpContextAccessor.HttpContext.Session.GetString("User"));
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