using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace No_Vk.Domain.Models.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notice> Notices { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>()
                .HasOne(f => f.Me)
                .WithMany(u => u.Friends)
                .HasForeignKey(f => f.MyId);
            
            modelBuilder.Entity<User>()
                .HasMany(u => u.Notices)
                .WithOne(n => n.Addressee);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Chats)
                .WithMany(c => c.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Memberships",
                    m => m.HasOne<Chat>()
                        .WithMany().HasForeignKey("ChatId"),
                    m => m.HasOne<User>()
                        .WithMany().HasForeignKey("UserId"));
        }
    }
}
