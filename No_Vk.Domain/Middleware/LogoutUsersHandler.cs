using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace No_Vk.Domain.Middleware
{
    public class LogoutUsersHandler
    {
        private readonly RequestDelegate _next;

        private readonly string[] _allowedPaths = new[]
        {
            "/login/login",
            "/login/registration",
            "/"
        };
        public LogoutUsersHandler(RequestDelegate nextDelegate)
        {
            _next = nextDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Session.Keys.Contains("User"))
            {
                string userId = context.Session.GetString("User");

                if (string.IsNullOrEmpty(userId) && !_allowedPaths.Contains(context.Request.Path.Value))
                {
                    context.Response.Redirect("/");
                }
            }
            else
            {
                if (!_allowedPaths.Contains(context.Request.Path.Value))
                {
                    context.Response.Redirect("/");
                }
            }
            await _next(context);
        }
    }
}
