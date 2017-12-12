using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Logging.Extend
{
    internal static class ListExtend
    {
        public static void AddSynchronized<T>(this IList<T> list, T t)
        {
            lock (list)
            {
                list.Add(t);
            }
        }
    }
}
