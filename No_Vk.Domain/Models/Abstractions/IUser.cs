namespace No_Vk.Domain.Models.Abstractions
{
    public interface IUser : IIdentifier
    {
        public string Email { get; set; }
        public RoleNames Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public enum RoleNames
    {
        Base,
        Administrator,
        Platon,
        Deleted
    }
}
