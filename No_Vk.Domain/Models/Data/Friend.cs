using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using No_Vk.Domain.Models.Abstractions;

namespace No_Vk.Domain.Models.Data
{
    public class Friend : IIdentifier
    {
        //TODO: Remove this constructor
        public Friend() { }
        public Friend(User user)
        {
            User = user;
            UserId = user.Id;
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}