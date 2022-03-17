using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using No_Vk.Domain.Models.Abstractions;

namespace No_Vk.Domain.Models.Data
{
    public sealed class Friend : IIdentifier
    {
        //TODO: Remove this constructor
        public Friend() { }
        public Friend(User user, User friendUser)
        {
            Me = user;
            MyId = user.Id;
            FriendUser = friendUser;
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public string Id { get; set; }
        
        public string MyId { get; set; }
        public User Me { get; set; }
        
        public User FriendUser { get; set; }
    }
}