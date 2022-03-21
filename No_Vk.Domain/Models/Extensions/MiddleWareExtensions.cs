using Microsoft.AspNetCore.Builder;
using No_Vk.Domain.Middleware;

namespace No_Vk.Domain.Models.Extensions
{
    public static class MiddleWareExtensions
    {
        public static IApplicationBuilder UseLogoutUsersHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogoutUsersHandler>();
        }

        public static IApplicationBuilder UseAdminDefaultLogin(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AdminDefaultLogin>();
        }
    }
}
