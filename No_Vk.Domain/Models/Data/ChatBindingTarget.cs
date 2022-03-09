using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace No_Vk.Domain.Models.Data
{
    public class ChatBindingTarget
    {
        [Required]
        public string Name { get; set; }

        public Chat ToChat()
        {
            Chat chat = new(Name, new());

            return chat;
        }
    }
}
