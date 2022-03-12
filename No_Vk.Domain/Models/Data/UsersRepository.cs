using Microsoft.EntityFrameworkCore;
using No_Vk.Domain.Models.Abstractions;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace No_Vk.Domain.Models.Data
{
    public sealed class UsersRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UsersRepository(UserDbContext context)
        {
            _context = context;
        }
        //TODO: Добавить include в методы!
        public IQueryable<User> GetUsers() => _context.Users
            .Include(u => u.Chats)
            .ThenInclude(c => c.Users);
        public User GetUser(string id) => GetUsers().FirstOrDefault(u => u.Id == id);
        public IQueryable<Chat> GetChats() => _context.Chats
            .Include(c => c.Messages)
            .Include(c => c.Users)
            .ThenInclude(u => u.Chats);
        public Chat GetChat(string id) => GetChats().FirstOrDefault(i => i.Id == id);
        public IQueryable<Message> GetMessages() => _context.Messages;
        public Message GetMessage(string id) => _context.Messages.FirstOrDefault(i => i.Id == id);
        public IQueryable<Friend> GetFriends() => _context.Friends;
        public Friend GetFriend(string id) => _context.Friends.FirstOrDefault(i => i.Id == id);
        public IQueryable<Notice> GetNotices() => _context.Notices;
        public Notice GetNotice(string id) => _context.Notices.FirstOrDefault(i => i.Id == id);

        public void AddUser(UserRegistrationBindingTarget target)
        {
            try
            {
                User user = target.ToUser();
                _context.Users.Add(user);
            }
            catch (Exception e)
            {
                string message = e.Message;
            }
        }
        public void AddChat(Chat chat) => _context.Chats.Add(chat);
        public void AddMessage(Message message) => _context.Messages.Add(message);
        public void AddFriend(Friend friend) => _context.Friends.Add(friend);
        public void AddNotice(Notice notice) => _context.Notices.Add(notice);

        public void DeleteUser(User user)
        {
            user.Role = RoleNames.Deleted;
            _context.Users.Update(user);
        }
        public void DeleteChat(Chat chat) => _context.Chats.Remove(chat);
        public void DeleteMessage(Message message) => _context.Messages.Remove(message);
        public void DeleteFriend(Friend friend) => _context.Friends.Remove(friend);
        public void DeleteNotice(Notice notice) => _context.Notices.Remove(notice);

        public void UpdateUser(User user) => _context.Users.Update(user);
        public void UpdateChat(Chat chat) => _context.Chats.Update(chat);
        public void UpdateMessage(Message message) => _context.Messages.Update(message);
        public void UpdateFriend(Friend friend) => _context.Friends.Update(friend);
        public void UpdateNotice(Notice notice) => _context.Notices.Update(notice);

        public void Save() => _context.SaveChanges();

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
