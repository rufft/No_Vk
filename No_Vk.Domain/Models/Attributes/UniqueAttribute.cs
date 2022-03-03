using Microsoft.EntityFrameworkCore;
using No_Vk.Domain.Models.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace No_Vk.Domain.Models.Attributes
{
    public class UniqueAttribute : ValidationAttribute
    {
    }
}
