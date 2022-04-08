using No_Vk.Domain.Models.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace No_Vk.Domain.Models.Data
{
    public sealed class Notice : IIdentifier
    {
        private Notice() { }

        public Notice(string name, User addressee, string description, string @object, NoticeType type)
        {
            Name = name;
            Addressee = addressee;
            Description = description;
            Object = @object;
            Type = type;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; init; }
        public string Name { get; set; }
        public User Addressee { get; init; }
        public string Description { get; set; }
        public string Object { get; init; }
        public NoticeType Type { get; init; }
    }

    public enum NoticeType
    {
        None,
        FriendInvite,
        ChatInvite
    }
}
