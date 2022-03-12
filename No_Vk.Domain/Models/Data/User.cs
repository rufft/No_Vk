using System;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace No_Vk.Domain.Models
{
    public class User : IUser
    {
        //TODO: delete this constructor
        public User(string email, string login, string password, RoleNames role)
        {
            Email = email;
            Login = login;
            Password = password;
            Role = role;
        }

        public User(string email, string login, string password, RoleNames role, DateTime time)
        {
            Email = email;
            Login = login;
            Password = password;
            Role = role;
            CreatedTime = time;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public RoleNames Role { get; set; }
        
        public DateTime CreatedTime { get; set; }
        public List<Chat> Chats { get; set; }
    }
}