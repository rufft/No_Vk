using No_Vk.Domain.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace No_Vk.Domain.Models.Abstractions
{
    public interface IUserRepository : IDisposable
    {
        //Create
        public void AddUser(UserRegistrationBindingTarget user);
        public Task AddUserAsync(UserRegistrationBindingTarget target);
        public void AddChat(Chat chat);
        public Task AddChatAsync(Chat chat);
        public void AddMessage(Message message);
        public Task AddMessageAsync(Message message);
        public void AddNotice(Notice notice);
        public Task AddNoticeAsync(Notice notice);

        //Read
        public IQueryable<User> GetUsers();
        public Task<List<User>> GetUsersAsync();
        public User GetUser(string id);
        public Task<User> GetUserAsync(string id);
        public IQueryable<Chat> GetChats();
        public Task<List<Chat>> GetChatsAsync();
        public Chat GetChat(string id);
        public Task<Chat> GetChatAsync(string id);
        public IQueryable<Message> GetMessages();
        public Task<List<Message>> GetMessagesAsync();
        public Message GetMessage(string id);
        public Task<Message> GetMessageAsync(string id);
        public IQueryable<Notice> GetNotices();
        public Task<List<Notice>> GetNoticesAsync();
        public Notice GetNotice(string id);
        public Task<Notice> GetNoticeAsync(string id);

        //Update
        public void UpdateUser(User user);
        public void UpdateChat(Chat chat);
        public void UpdateMessage(Message message);
        public void UpdateNotice(Notice notice);

        //Delete
        public void DeleteUser(User user);
        public void DeleteChat(Chat chat);
        public void DeleteMessage(Message message);
        public void DeleteNotice(Notice notice);



        public void Save();
        public Task SaveAsync();
    }
}
