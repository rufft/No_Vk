using No_Vk.Domain.Models.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace No_Vk.Domain.Models.Data
{
    public class Notice : IIdentifier
    {
        public Notice() { }
        public Notice(string name, User user, string description, string jsonModel, NoticeType type)
        {
            Name = name;
            User = user;
            Description = description;
            JSONModel = jsonModel;
            Type = type;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public string JSONModel { get; set; }
        public NoticeType Type { get; set; }
    }

    public enum NoticeType
    {
        FriendInvite,
        ChatInvite
    }
}
