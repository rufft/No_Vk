using System;
using No_Vk.Domain.Models.Data;
using System.Collections.Generic;
using No_Vk.Types;

namespace No_Vk.Domain.Models.ViewModels
{
    public class ChatViewModel
    {
        public ChatBindingTarget ChatTarget { get; set; }
        public Dictionary<string, bool> Users { get; set; }
    }
}
