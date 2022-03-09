using System.ComponentModel.DataAnnotations;

namespace No_Vk.Domain.Models.Data
{
    public class UserLoginBindeingTraget
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
