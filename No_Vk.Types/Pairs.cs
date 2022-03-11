using System.Collections.Generic;
using System.Linq;

namespace No_Vk.Types
{
    public class Pairs<T1, T2> : List<Pair<T1, T2>>
    {
        public T2 this[T1 value1]
        {
            get => this.FirstOrDefault(p => p.Value1.Equals(value1)).Value2;
            set
            {
               var pair = this.FirstOrDefault(p => p.Value1.Equals(value1));
               pair.Value2 = value;
            }
        }
        public T1 this[T2 value2]
        {
            get => this.FirstOrDefault(p => p.Value2.Equals(value2)).Value1;
            set
            {
                var pair = this.FirstOrDefault(p => p.Value1.Equals(value2));
                pair.Value1 = value;
            }
        }
    }
}