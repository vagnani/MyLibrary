using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Collections
{
    public static class General
    {
        public static T CopyFrom<T>(this T list) where T : class, IEnumerable, ICollection, IList, new()
        {
            T result = new T();
            foreach (var n in list)
            {
                result.Add(n);
            }
            return result;
        }
    }
}
