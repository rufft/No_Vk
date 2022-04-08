using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace No_Vk.Domain.Models.Attributes
{
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public class Password : ValidationAttribute
    {
        private readonly PasswordOption[] _passwordOptions;
        private readonly int _minLength;
        
        public Password(int minLength, params PasswordOption[] passwordOptions)
        {
            _minLength = minLength;
            _passwordOptions = passwordOptions;
        }

        public override bool IsValid(object value)
        {
            if (value is not string password)
            {
                ErrorMessage = "Enter password";
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                ErrorMessage = "Enter password";
                return false;
            }

            if (password.Length < _minLength)
            {
                ErrorMessage = $"Password must be longer then {_minLength}";
                return false;
            }

            
            foreach (var opt in _passwordOptions)
            {
                switch (opt)
                {
                    case PasswordOption.RequiredNumbers:
                        if (!Regex.IsMatch(password, @"(\d)"))
                        {
                            ErrorMessage = "There must be at least one digit in the password";
                            return false;
                        }
                        break;
                    case PasswordOption.RequiredCapitalLetter:
                        if (!Regex.IsMatch(password, @"[A-Z]"))
                        {
                            ErrorMessage = "There must be at least one capital letter in the password";
                            return false;
                        }
                        break;
                    case PasswordOption.RequiredSpecialSymbols:
                        if (!Regex.IsMatch(password, @"[!\¹\;\%\:@#$%\^&*\(\)\-_ =+?]"))
                        {
                            ErrorMessage = "There must be at least one special symbol in the password";
                            return false;
                        }
                        break;
                }
            }
            return true;
        }
    }
    
    public enum PasswordOption
    {
        RequiredCapitalLetter,
        RequiredSpecialSymbols,
        RequiredNumbers
    }
}