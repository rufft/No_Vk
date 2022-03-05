using No_Vk.Domain.Models.Data;
using System.Collections.Generic;

namespace No_Vk.Domain.Models.ViewModels
{
    public class ChatViewModel
    {
        public ChatBindingTarget ChatTraget { get; set; }
        public List<User> Users { get; set; }
    }
}
