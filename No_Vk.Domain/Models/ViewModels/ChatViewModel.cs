using No_Vk.Domain.Models.Data;
using System.Collections.Generic;

namespace No_Vk.Domain.Models.ViewModels
{
    public class ChatViewModel
    {
        public ChatBindingTarget ChatTarget { get; set; }
        public Dictionary<string, bool> Users { get; set; }
    }
}
