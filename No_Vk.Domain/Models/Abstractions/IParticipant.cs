namespace No_Vk.Domain.Models.Abstractions
{
    public interface IParticipant : IIdentifier
    {
        public User User { get; set; }
        public Chat Chat { get; set; }
        public ChatRole ChatRole { get; set; }
    }
    public enum ChatRole
    {
        Basic,
        Boss,
        Аssistant
    }
}
