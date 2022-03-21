using System.ComponentModel.DataAnnotations.Schema;
using No_Vk.Domain.Models.Abstractions;

namespace No_Vk.Domain.Models.Data
{
    public class ChatUser : IIdentifier
    {
        private ChatUser() { }
        public ChatUser(User user, Chat chat)
        {
            User = user;
            Chat = chat;
            UserId = user.Id;
            ChatId = chat.Id;
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; init; }
        public string UserId { get; }
        public string ChatId { get; }
        public User User { get; }
        public Chat Chat { get; }
    }
}
