using No_Vk.Domain.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace No_Vk.Domain.Models.ViewModels
{
    public class AddFriendResponseViewModel
    {
        [Required]
        public bool Response { get; set; }

    }
}
