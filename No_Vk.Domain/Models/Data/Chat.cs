using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace No_Vk.Domain.Models
{
    public class Chat : IChat
    {
        public Chat(string name, List<User> users) 
        {
            Name = name;
            Users = users;
        }
        public Chat(string name)
        {
            Name = name;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Message> Messages { get; set; }
        public List<User> Users { get; set; }
    }
}
