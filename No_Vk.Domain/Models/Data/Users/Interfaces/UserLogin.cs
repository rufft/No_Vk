using No_Vk.Domain.Models.Abstractions;

namespace No_Vk.Domain.Models.Data.Users.Interfaces
{
    public class UserLogin : IUserLoginData, IIdentifier
    {
        public UserLogin(string email, string password, string id)
        {
            Email = email;
            Password = password;
            Id = id;
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Id { get; init; }
    }
}