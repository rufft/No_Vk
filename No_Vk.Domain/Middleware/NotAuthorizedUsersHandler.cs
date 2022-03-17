using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace No_Vk.Domain.Middleware
{
    public class NotAuthorizedUsersHandler
    {
        private readonly RequestDelegate _next;
        public NotAuthorizedUsersHandler(RequestDelegate nextDelegate)
        {
            _next = nextDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Session.Keys.Contains("User"))
            {
                string userId = context.Session.GetString("User");

                if (string.IsNullOrEmpty(userId) && (context.Request.Path.Value != "/login/login" || context.Request.Path.Value != "/login/registration"))
                {
                    context.Response.Redirect("/login/login");
                }
            }
            else
            {
                if (context.Request.Path.Value != "/login/login" && context.Request.Path.Value != "/login/registration")
                {
                    context.Response.Redirect("/login/login");
                }
            }
            await _next(context);
        }
    }
}
