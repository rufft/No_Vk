using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using No_Vk.Domain.Models.Data.Users;
using No_Vk.Domain.Models.Extensions;
using No_Vk.Domain.Services;

namespace No_Vk.Domain.Middleware
{
    public class LogoutUsersHandler
    {
        private readonly RequestDelegate _next;
  
        public LogoutUsersHandler(RequestDelegate nextDelegate)
        {
            _next = nextDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Session.Keys.Contains("User"))
            {
                SessionUser user = context.Session.GetObject<SessionUser>("User");

                if (user is null && (context.Request.Path.Value != "/login/login" || context.Request.Path.Value != "/login/registration"))
                {
                    context.Response.Redirect("/login/login");
                }
            }
            else
            {
                if (context.Request.Path.Value != "/login/login" || context.Request.Path.Value != "/login/registration")
                {
                    context.Response.Redirect("/login/login");
                }
            }
            await _next(context);
        }
    }
}
