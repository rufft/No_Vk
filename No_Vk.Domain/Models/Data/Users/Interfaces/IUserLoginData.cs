namespace No_Vk.Domain.Models.Data.Users.Interfaces
{
    public interface IUserLoginData
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}