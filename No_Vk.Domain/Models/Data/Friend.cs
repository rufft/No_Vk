using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using No_Vk.Domain.Models.Abstractions;

namespace No_Vk.Domain.Models.Data
{
    public class Friend : IIdentifier
    {
        private Friend() { }

        public Friend(User user, User friendUser)
        {
            Me = user;
            MyId = user.Id;
            FriendUser = friendUser;
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public string Id { get; init; }
        
        public string MyId { get; }
        public User Me { get; }
        
        public User FriendUser { get; }
    }
}