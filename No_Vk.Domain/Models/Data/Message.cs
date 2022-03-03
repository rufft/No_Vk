using No_Vk.Domain.Models.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace No_Vk.Domain.Models
{
    public class Message : IMessage
    {
        private Message() { }
        public Message(User fromUser, Chat chat, string messageText)
        {
            FromUser = fromUser;
            Chat = chat;
            MessageText = messageText;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public User FromUser { get; set; }
        public Chat Chat { get; set; }
        public string MessageText { get; set; }
    }
}
