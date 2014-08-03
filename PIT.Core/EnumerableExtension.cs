using System;
using System.Collections.Generic;

namespace PIT.Core
{
    public static class EnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}