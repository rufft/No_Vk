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
            if (value?.ToString() == null)
            {
                ErrorMessage = "Введите пароль";
                return false;
            }
            
            if (value.ToString()?.Length < _minLength) { return false; }

            string password = value.ToString();
            
            foreach (var opt in _passwordOptions)
            {
                switch (opt)
                {
                    case PasswordOption.RequiredNumbers:
                        if (!Regex.IsMatch(password, @"(\d)"))
                        {
                            ErrorMessage = "Минимум одна цифра в пароле";
                            return false;
                        }
                        break;
                    case PasswordOption.RequiredCapitalLetter:
                        if (!Regex.IsMatch(password, @"[A-Z]"))
                        {
                            ErrorMessage = "Минимум одна заглавная буква в пароле";
                            return false;
                        }
                        break;
                    case PasswordOption.RequiredSpecialSymbols:
                        if (!Regex.IsMatch(password, @"[!\№\;\%\:@#$%\^&*\(\)\-_=+?]"))
                        {
                            ErrorMessage = "Минимум один специальный символ в пароле";
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