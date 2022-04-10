using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public void CreateChat(ChatBindingTarget chatBindingTarget, params string[] userIds)
        {
            var chat = chatBindingTarget.ToChat();
            
            var users = new List<User>();

            chat.Users = new();
            
            foreach (var userId in userIds)
            {
                var user = _dbContext.Users
                    .Include(u => u.Chats)
                    .ThenInclude(c => c.Users)
                    .FirstOrDefault(u => u.Id == userId);

                if (user is null) continue;
                
                users.Add(user);
                chat.Users.Add(user);
            }
            
            foreach (var user in users)
            {
                user.Chats ??= new();
                user.Chats.Add(chat);
            }

            try
            {
                _dbContext.Chats.Add(chat);

                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public void CreateMessage(Chat chat, Message message)
        {
            if (message == null || chat == null) return;

            chat.Messages.Add(message);

            _dbContext.Chats.Update(chat);
            _dbContext.SaveChanges();
        }
    }
}
