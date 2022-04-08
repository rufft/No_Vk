using No_Vk.Domain.Models.Abstractions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace No_Vk.Domain.Models
{
    public sealed class Message : IIdentifier
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
        public User FromUser { get; init; }
        public Chat Chat { get; init; }
        public DateTime MessageCreationTime { get; init; }
        public string MessageText { get; set; }
    }
}
