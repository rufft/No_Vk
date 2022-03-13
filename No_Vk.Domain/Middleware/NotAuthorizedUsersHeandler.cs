using Microsoft.AspNetCore.Http;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace No_Vk.Domain.Middleware
{
    public class NotAuthorizedUsersHeandler
    {
        private RequestDelegate _next;
        public NotAuthorizedUsersHeandler(RequestDelegate nextDelegate)
        {
            _next = nextDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Session.Keys.Contains("Addressee"))
            {
                string userId = context.Session.GetString("Addressee");

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
