using System;
using No_Vk.Domain.Models.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using No_Vk.Domain.Models.Data;
using No_Vk.Domain.Models.Data.Users;
using No_Vk.Domain.Models.Data.Users.Interfaces;

namespace No_Vk.Domain.Models
{
    public class User : IUserMainData, IUserLoginData, IUserFrequentlyChangingData
    {
        private User() { }
        public User(string email, string userName, string password, RoleNames role)
        {
            Email = email;
            UserName = userName;
            Password = password;
            Role = role;
            CreatedTime = DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; init; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleNames Role { get; set; }
        public DateTime CreatedTime { get; }
        
        public List<Notice> Notices { get; set; }
        public List<Chat> Chats { get; set; }
        public List<Friend> Friends { get; set; }

        public SessionUser ToSessionUser() => new(Id, UserName, Role, CreatedTime, Friends);
    }
}