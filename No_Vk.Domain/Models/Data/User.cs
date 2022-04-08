using System;
using No_Vk.Domain.Models.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Models
{
    public sealed class User : IIdentifier
    {
        private User() { }

        public User(string email, string login, string password, RoleNames role)
        {
            Email = email;
            Login = login;
            Password = password;
            Role = role;
            CreatedTime = DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; init; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public RoleNames Role { get; set; }
        
        public DateTime CreatedTime { get; init; }
        public List<Chat> Chats { get; set; }
        public List<Friend> Friends { get; set; }
    }
}