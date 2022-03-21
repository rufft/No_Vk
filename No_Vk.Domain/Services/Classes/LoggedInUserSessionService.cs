using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Extensions;

namespace No_Vk.Domain.Services
{
    public class LoggedInUserSessionService : ILoggedInUserSessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _usersRepository;

        public LoggedInUserSessionService(IUserRepository usersRepository, IHttpContextAccessor httpContextAccessor)
        {
            _usersRepository = usersRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public User Me => _httpContextAccessor.HttpContext.Session.GetObject<User>("User");

        public void UpdateSessionDataAboutMe()
        {
            var user = _usersRepository.GetUser(Me.Id);
            _httpContextAccessor.HttpContext.Session.SetObject("User", user);
        }
        public async Task UpdateSessionDataAboutMeAsync()
        {
            var user = await _usersRepository.GetUserAsync(Me.Id);
            _httpContextAccessor.HttpContext.Session.SetObject("User", user);
        }
    }
}