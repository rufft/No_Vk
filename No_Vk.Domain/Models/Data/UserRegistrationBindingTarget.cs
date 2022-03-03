using No_Vk.Domain.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace No_Vk.Domain.Models.Data
{
    public class UserRegistrationBindingTarget
    {
        [Required]
        [UIHint("String")]
        public string Login { get; set;}

        [Required]
        [UIHint("Password")]
        public string Password { get; set;}

        [Required]
        [UIHint("EmailAddress", "Мыло")]
        public string Email { get; set; }

        public User ToUser() => new(Email, Login, Password, RoleNames.Base);
    }
}
