using Microsoft.EntityFrameworkCore;
using No_Vk.Domain.Models.Abstractions;

namespace No_Vk.Domain.Models.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) 
        { }
    }
}
