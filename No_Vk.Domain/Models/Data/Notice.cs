using No_Vk.Domain.Models.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace No_Vk.Domain.Models.Data
{
    public class Notice : IIdentifier
    {
        private Notice() { }
        public Notice(string name, User addressee, string description, string jsonModel, NoticeType type)
        {
            Name = name;
            Addressee = addressee;
            Description = description;
            Object = jsonModel;
            Type = type;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; init; }
        public string Name { get; }
        public User Addressee { get; }
        public string Description { get; }
        public string Object { get; }
        public NoticeType Type { get; init; }
    }

    public enum NoticeType
    {
        FriendInvite,
        ChatInvite
    }
}
