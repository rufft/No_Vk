using Microsoft.AspNetCore.Http;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace No_Vk.Domain.Middleware
{
    public class AdminDefaultLogin
    {
        private RequestDelegate _next;
        public AdminDefaultLogin(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserRepository userRepository)
        {
            if (!context.Session.Keys.Contains("User"))
            {
                User user = userRepository.GetUsers().FirstOrDefault(u => u.Email == "admin@dev.ru");

                context.Session.SetObject<User>("User", user);
            }

            await _next(context);
        }
    }
}
