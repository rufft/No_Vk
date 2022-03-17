using Microsoft.AspNetCore.Builder;
using No_Vk.Domain.Middleware;
using No_Vk.Domain.Models.Abstractions;

namespace No_Vk.Domain.Models.Extensions
{
    public static class MiddleWareExtentions
    {
        public static IApplicationBuilder UseNotAuthorizedUsersHeandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NotAuthorizedUsersHandler>();
        }

        public static IApplicationBuilder UseAdminDefaultLogin(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AdminDefaultLogin>();
        }
    }
}
