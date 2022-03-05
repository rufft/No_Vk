using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using No_Vk.Domain.Models.Data;
using Microsoft.AspNetCore.Http;
using No_Vk.Domain.Models.Extensions;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Services;
using No_Vk.Domain.Models.Notices;

namespace No_Vk.Domain
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddDbContext<UserDbContext>(opts =>
            {
                opts.UseSqlServer(Configuration.GetConnectionString("no_vkConnection"));
            });
            services.AddSession(opts =>
            {
                opts.IdleTimeout = TimeSpan.FromSeconds(600);
            });
            services.AddLogging();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped<INoticeHeandlerService, NoticeHeandlerService>();
            services.AddScoped<IChatHeandlerService, ChatHeandlerService>();
            services.AddScoped<IUserDataService, UserDataService>();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ILogger<Startup> logger,
            IUserRepository userRepository)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseAdminDefaultLogin();
            app.UseNotAuthorizedUsersHeandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/chats/{*catchall}", "/Chats/IndexChats");
                endpoints.MapFallbackToPage("/notice/{*catchall}", "/Notice/IndexNotice");
            });

            app.Run(async context => await context.Response.WriteAsync("Такой страницы нет!"));
        }
    }
}
