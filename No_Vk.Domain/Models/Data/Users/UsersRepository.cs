using Microsoft.EntityFrameworkCore;
using No_Vk.Domain.Models.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace No_Vk.Domain.Models.Data
{
    public sealed class UsersRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UsersRepository(UserDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetUsers()
        {
            return _context.Users
                .Include(u => u.Friends)
                .ThenInclude(f => f.FriendUser)
                .Include(u => u.Notices)
                .ThenInclude(n => n.Addressee);
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Friends)
                .ThenInclude(f => f.FriendUser)
                .Include(u => u.Notices)
                .ThenInclude(n => n.Addressee).ToListAsync();
        }

        public User GetUser(string id)
        {
            return GetUsers().FirstOrDefault(u => u.Id == id);
        }
        public async Task<User> GetUserAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<Chat> GetChats()
        {
            return _context.Chats
                .Include(c => c.Messages)
                .Include(c => c.Users);
        }
        public async Task<List<Chat>> GetChatsAsync()
        {
            return await _context.Chats
                .Include(c => c.Messages)
                .Include(c => c.Users)
                .ToListAsync();
        }

        public Chat GetChat(string id)
        {
            return GetChats().FirstOrDefault(c => c.Id == id);
        }
        public async Task<Chat> GetChatAsync(string id)
        {
            return await _context.Chats.FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<Message> GetMessages()
        {
            return _context.Messages;
        }
        public async Task<List<Message>> GetMessagesAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public Message GetMessage(string id)
        {
            return _context.Messages.FirstOrDefault(i => i.Id == id);
        }
        public async Task<Message> GetMessageAsync(string id)
        {
            return await _context.Messages.FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<Notice> GetNotices()
        {
            return _context.Notices;
        }
        public async Task<List<Notice>> GetNoticesAsync()
        {
            return await _context.Notices.ToListAsync();
        }

        public Notice GetNotice(string id)
        {
            return _context.Notices.FirstOrDefault(i => i.Id == id);
        }
        public async Task<Notice> GetNoticeAsync(string id)
        {
            return await _context.Notices.FirstOrDefaultAsync(i => i.Id == id);
        }
        

        public void AddUser(UserRegistrationBindingTarget target)
        {
            User user = target.ToUser();
            
            if (user == null) { return; }
            
            _context.Users.Add(user);
        }
        public async Task AddUserAsync(UserRegistrationBindingTarget target)
        {
            User user = target.ToUser();
            
            if (user == null) { return; }
            
            await _context.Users.AddAsync(user);
        }

        public void AddChat(Chat chat)
        {
            _context.Chats.Add(chat);
        }
        public async Task AddChatAsync(Chat chat)
        {
            await _context.Chats.AddAsync(chat);
        }

        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
        }
        public async Task AddMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public void AddNotice(Notice notice)
        {
            _context.Notices.Add(notice);
        }
        public async Task AddNoticeAsync(Notice notice)
        {
            await _context.Notices.AddAsync(notice);
        }

        
        public void DeleteUser(User user)
        {
            user.Role = RoleNames.Deleted;
            _context.Users.Update(user);
        }
        public void DeleteChat(Chat chat)
        {
            _context.Chats.Remove(chat);
        }
        public void DeleteMessage(Message message)
        {
            _context.Messages.Remove(message);
        }
        public void DeleteNotice(Notice notice)
        {
            _context.Notices.Remove(notice);
        }


        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
        public void UpdateChat(Chat chat)
        {
            _context.Chats.Update(chat);
        }
        public void UpdateMessage(Message message)
        {
            _context.Messages.Update(message);
        }
        public void UpdateNotice(Notice notice)
        {
            _context.Notices.Update(notice);
        }

        
        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        #region Dispose
        private bool _disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
