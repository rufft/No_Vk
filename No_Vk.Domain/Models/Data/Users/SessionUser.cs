using System;
using System.Collections.Generic;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data.Users.Interfaces;

namespace No_Vk.Domain.Models.Data.Users
{
    public class SessionUser : IUserMainData
    {
        public SessionUser(string id, string userName, RoleNames role, DateTime createdTime, List<Friend> friends)
        {
            Id = id;
            UserName = userName;
            Role = role;
            CreatedTime = createdTime;
            Friends = friends;
        }

        public string Id { get; init; }
        public string UserName { get; set; }
        public RoleNames Role { get; set; }
        public DateTime CreatedTime { get; }
        public List<Friend> Friends { get; set; }
    }
}