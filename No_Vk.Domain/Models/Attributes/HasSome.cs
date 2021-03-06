using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace No_Vk.Domain.Models.Attributes
{
    public class HasSome : ValidationAttribute
    {
        private readonly int _minCount;

        public HasSome(int minCount)
        {
            _minCount = minCount;
        }

        public override bool IsValid(object value)
        {
            if (value is not ICollection collection) { return false; }

            return collection.Count >= _minCount;
        }
    }
}