using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace No_Vk.Domain.Models.Attributes
{
    public class Email : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value?.ToString() == null)
            {
                ErrorMessage = "������� �����";
                return false;
            }

            string email = value.ToString();
            
            var trimmedEmail = email.Trim();
            
            return Regex.IsMatch(trimmedEmail, @"[a-z0-9]+@[a-z]+\.[a-z]{2,3}");
        }
    }
}