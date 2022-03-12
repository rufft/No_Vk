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
                ErrorMessage = "������� �����";
                return false;
            }

            string login = value.ToString();
            
            bool isLenghtValid = login.Length >= _minLenght && login.Length <= _maxLenght;
            if (isLenghtValid)
            {
                if (login.Contains(" "))
                {
                    ErrorMessage = "����� �� ������ ��������� ��������";
                    return false;
                }
                return true;
            }

            ErrorMessage = "����� �� �������� �� �����";
            return false;
        }
    }
}