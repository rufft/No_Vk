using System.Threading.Tasks;
using No_Vk.Domain.Models;

namespace No_Vk.Domain.Services
{
    public interface ILoggedInUserSessionService
    {
        public User Me { get; }
        public void UpdateSessionDataAboutMe();
        public Task UpdateSessionDataAboutMeAsync();
    }
}