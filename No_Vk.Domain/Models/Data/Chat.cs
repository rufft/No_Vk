using No_Vk.Domain.Models.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace No_Vk.Domain.Models
{
    public class Chat : IChat
    {
        public Chat(string name) 
        {
            Name = name;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
