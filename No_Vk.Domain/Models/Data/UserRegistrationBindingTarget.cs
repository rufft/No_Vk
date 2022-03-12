using System;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Attributes;

namespace No_Vk.Domain.Models.Data
{
    public class UserRegistrationBindingTarget
    {
        [Login(4, 15)]
        public string Login { get; set;}

        [Password(8,
            PasswordOption.RequiredNumbers,
            PasswordOption.RequiredCapitalLetter)]
        public string Password { get; set;}

        [Email]
        public string Email { get; set; }

        public User ToUser() => new(Email, Login, Password, RoleNames.Base, DateTime.Now);
    }
}
