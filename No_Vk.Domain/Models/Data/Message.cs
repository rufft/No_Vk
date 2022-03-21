using No_Vk.Domain.Models.Abstractions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace No_Vk.Domain.Models
{
    public class Message : IIdentifier
    {
        private Message() { }
        public Message(User fromUser, Chat chat, string messageText)
        {
            FromUser = fromUser;
            Chat = chat;
            MessageText = messageText;
            MessageCreationTime = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; init; }
        public User FromUser { get; }
        public Chat Chat { get; }
        public DateTime MessageCreationTime { get; }
        public string MessageText { get; set; }
    }
}
