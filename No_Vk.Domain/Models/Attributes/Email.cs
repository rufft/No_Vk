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
                ErrorMessage = "Enter email";
                return false;
            }

            string email = value.ToString();
            
            var trimmedEmail = email.Trim();
            
            var isMatch = Regex.IsMatch(trimmedEmail, @"[a-z0-9]+@[a-z]+\.[a-z]{2,3}");
            
            if (isMatch) return true;
            ErrorMessage = "Invalid Email";
            return false;
        }
    }
}