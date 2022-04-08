using Microsoft.AspNetCore.Http;
using No_Vk.Domain.Models.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Middleware
{
    public class AdminDefaultLogin
    {
        private readonly RequestDelegate _next;
        public AdminDefaultLogin(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserDbContext dbContext)
        {
            if (!context.Session.Keys.Contains("User"))
            {
                var userId = dbContext.Users.FirstOrDefault(u => u.Email == "admin@dev.ru").Id;

                context.Session.SetString("User", userId);
            }

            await _next(context);
        }
    }
}
