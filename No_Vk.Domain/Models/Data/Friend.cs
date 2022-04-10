using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using No_Vk.Domain.Models.Abstractions;

namespace No_Vk.Domain.Models.Data
{
    public sealed class Friend : IIdentifier
    {
        private Friend() { }

        public Friend(User friendUser)
        {
            FriendId = friendUser.Id;
        }
        public Friend(string friendId)
        {
            FriendId = friendId;
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public string Id { get; init; }
        
        public string FriendId { get; init; }
    }
}