using System.Threading.Tasks;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Services
{
    public class ChatHandlerService : IChatHandlerService
    {
        private readonly UserDbContext _dbContext;
        public ChatHandlerService(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateChatAsync(ChatBindingTarget chatBindingTarget, params User[] users)
        {
            var chat = chatBindingTarget.ToChat();

            await _dbContext.Chats.AddAsync(chat);

            foreach (var user in users)
            {
                chat.Users?.Add(user);
                
                user.Chats ??= user.Chats = new();
                user.Chats?.Add(chat);
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task CreateChatAsync(ChatBindingTarget chatBindingTarget, params string[] usersId)
        {
            var chat = chatBindingTarget.ToChat();

            await _dbContext.Chats.AddAsync(chat);

            foreach (var userId in usersId)
            {
                var user = await _dbContext.FindAsync<User>(userId);
                chat.Users?.Add(user);
                
                user.Chats ??= user.Chats = new();
                user.Chats?.Add(chat);
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task CreateMessageAsync(Chat chat, Message message)
        {
            if (message == null || chat == null) return;

            chat.Messages.Add(message);

            _dbContext.Chats.Update(chat);
            await _dbContext.SaveChangesAsync();
        }
    }
}
