namespace No_Vk.Domain.Models.Abstractions
{
    public interface IMessage : IIdentifier
    {
        public User FromUser { get; set; }
        public Chat Chat { get; set; }
        public string MessageText { get; set; }
    }
}
