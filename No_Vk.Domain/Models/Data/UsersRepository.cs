using Microsoft.EntityFrameworkCore;
using No_Vk.Domain.Models.Abstractions;
using System;
using System.Linq;

namespace No_Vk.Domain.Models.Data
{
    public class UsersRepository : IUserRepository
    {
        private UserDbContext _context;
        public UsersRepository(UserDbContext context)
        {
            _context = context;
        }
        //TODO: Добавить include в методы!
        public IQueryable<User> GetUsers() => _context.Users.Include(u => u.Chats);
        public User GetUser(string id) => _context.Users.Include(u => u.Chats).FirstOrDefault(i => i.Id == id);
        public IQueryable<Chat> GetChats() => _context.Chats.Include(c => c.Messages);
        public Chat GetChat(string id) => _context.Chats.Include(c => c.Messages).FirstOrDefault(i => i.Id == id);
        public IQueryable<Message> GetMessages() => _context.Messages;
        public Message GetMessage(string id) => _context.Messages.FirstOrDefault(i => i.Id == id);
        public IQueryable<Friend> GetFriends() => _context.Friends;
        public Friend GetFriend(string id) => _context.Friends.FirstOrDefault(i => i.Id == id);
        public IQueryable<Notice> GetNotices() => _context.Notices;
        public Notice GetNotice(string id) => _context.Notices.FirstOrDefault(i => i.Id == id);

        public void AddUser(User user) => _context.Users.Add(user);
        public void AddChat(Chat chat) => _context.Chats.Add(chat);
        public void AddMessage(Message message) => _context.Messages.Add(message);
        public void AddFriend(Friend friend) => _context.Friends.Add(friend);
        public void AddNotice(Notice notice) => _context.Notices.Add(notice);

        public void DeleteUser(User user)
        {
            user.Role = RoleNames.Deleted;
            _context.Users.Update(user);
        }
        public void DeleteChat(Chat chat)
        {
            /*var usersInChat = _context.Users.Where(u => u.Chats.Contains(chat));
            foreach (var User in usersInChat)
            {
                User.Chats.Remove(chat);
            }*/

            var messageList = _context.Messages.Where(m => m.Chat == chat);

            _context.Messages.RemoveRange(messageList);
            _context.Chats.Remove(chat);
        }
        public void DeleteMessage(Message Message) => _context.Messages.Remove(Message);
        public void DeleteFriend(Friend Friend) => _context.Friends.Remove(Friend);
        public void DeleteNotice(Notice Notice) => _context.Notices.Remove(Notice);

        public void UpdateUser(User user) => _context.Users.Update(user);
        public void UpdateChat(Chat chat) => _context.Chats.Update(chat);
        public void UpdateMessage(Message Message) => _context.Messages.Update(Message);
        public void UpdateFriend(Friend Friend) => _context.Friends.Update(Friend);
        public void UpdateNotice(Notice Notice) => _context.Notices.Update(Notice);

        public void Save() => _context.SaveChanges();

        #region Dispose
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
