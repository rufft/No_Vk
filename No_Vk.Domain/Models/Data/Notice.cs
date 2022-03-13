using No_Vk.Domain.Models.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace No_Vk.Domain.Models.Data
{
    public class Notice : IIdentifier
    {
        public Notice() { }
        public Notice(string name, User addressee, string description, string jsonModel, NoticeType type)
        {
            Name = name;
            Addressee = addressee;
            Description = description;
            Object = jsonModel;
            Type = type;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public User Addressee { get; set; }
        public string Description { get; set; }
        public string Object { get; set; }
        public NoticeType Type { get; set; }
    }

    public enum NoticeType
    {
        FriendInvite,
        ChatInvite
    }
}
