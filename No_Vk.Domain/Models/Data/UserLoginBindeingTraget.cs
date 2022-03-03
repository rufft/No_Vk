using System.ComponentModel.DataAnnotations;

namespace No_Vk.Domain.Models.Data
{
    public class UserLoginBindeingTraget
    {
        [Required]
        [UIHint("Password")]
        public string Password { get; set; }

        [Required]
        [UIHint("EmailAddress")]
        public string Email { get; set; }
    }
}
