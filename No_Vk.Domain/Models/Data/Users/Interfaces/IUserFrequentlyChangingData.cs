using System.Collections.Generic;

namespace No_Vk.Domain.Models.Data.Users.Interfaces
{
    public interface IUserFrequentlyChangingData
    {
        public List<Chat> Chats { get; set; }
        public List<Notice> Notices { get; set; }
    }
}