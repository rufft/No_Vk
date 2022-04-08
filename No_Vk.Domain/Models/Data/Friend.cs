using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using No_Vk.Domain.Models.Abstractions;

namespace No_Vk.Domain.Models.Data
{
    public sealed class Friend : IIdentifier
    {
        private Friend() { }

        public Friend(string myId, User friendUser)
        {
            MyId = myId;
            FriendId = friendUser.Id;
            FriendUser = friendUser;
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public string Id { get; init; }
        
        public string MyId { get; init; }
        
        public string FriendId { get; init; }
        public User FriendUser { get; init; }
    }
}