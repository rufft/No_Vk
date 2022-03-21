using System;
using No_Vk.Domain.Models.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace No_Vk.Domain.Models
{
    public class Chat : IIdentifier
    {
        private Chat() { }
        public Chat(string name, List<User> users) 
        {
            Name = name;
            Messages = new();
            Users = users;

            ChatCreationTime = DateTime.Now;
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; init; }
        public string Name { get; set; }
        public DateTime ChatCreationTime { get; }

        public List<Message> Messages { get; set; }
        public List<User> Users { get; set; }

    }
}
