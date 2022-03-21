using System.ComponentModel.DataAnnotations;
using No_Vk.Domain.Models.Attributes;

namespace No_Vk.Domain.Models.Data
{
    public class UserLoginBindingTarget
    {
        [Required]
        public string Password { get; set; }

        [Email]
        public string Email { get; set; }
    }
}
