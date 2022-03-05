using System.ComponentModel.DataAnnotations;

namespace No_Vk.Domain.Models.Data
{
    public class ChatBindingTarget
    {
        [Required]
        public string Name { get; set; }

        public Chat ToChat() => new(Name);
    }
}
