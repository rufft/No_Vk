using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using No_Vk.Domain.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace No_Vk.Domain.Models.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notice>()
                .HasOne(n => n.Addressee);


            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends);
            
            modelBuilder.Entity<User>()
                .HasMany(u => u.Chats)
                .WithMany(c => c.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "ChatUser",
                    cu => cu.HasOne<Chat>().WithMany().HasForeignKey("ChatId"),
                    cu => cu.HasOne<User>().WithMany().HasForeignKey("UserId"));
        }
    }
}
