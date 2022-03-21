using System;
using System.Collections.Generic;
using No_Vk.Domain.Models.Abstractions;

namespace No_Vk.Domain.Models.Data.Users.Interfaces
{
    public interface IUserMainData : IIdentifier
    {
        public string UserName { get; set; }
        public RoleNames Role { get; set; }
        public DateTime CreatedTime { get; }
        
        public List<Friend> Friends { get; set; }
    }
}