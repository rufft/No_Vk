using No_Vk.Domain.Models.Data;
using System.Collections.Generic;
using No_Vk.Domain.Models.Attributes;

namespace No_Vk.Domain.Models.ViewModels
{
    public class ChatViewModel
    {
        public ChatBindingTarget ChatTarget { get; set; }
        
        [HasSome(1)]
        public Dictionary<string, bool> UserIds { get; set; }
    }
}
