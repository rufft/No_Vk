using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace No_Vk.Domain.Models.Attributes
{
    public class Login : ValidationAttribute
    {
        private readonly int _minLenght;
        private readonly int _maxLenght;
        public Login(int minLenght, int maxLenght)
        {
            _minLenght = minLenght;
            _maxLenght = maxLenght;
        }

        public override bool IsValid(object value)
        {
            if (value?.ToString() == null)
            {
                ErrorMessage = "Enter login";
                return false;
            }

            var login = value.ToString();
            
            var isLenghtValid = login.Length >= _minLenght && login.Length <= _maxLenght;
            if (isLenghtValid)
            {
                if (!login.Contains(" ")) return true;
                ErrorMessage = "The login should not contain spaces";
                return false;
            }

            ErrorMessage = $"Login does not fit the size. From {_minLenght} to {_maxLenght}";
            return false;
        }
    }
}