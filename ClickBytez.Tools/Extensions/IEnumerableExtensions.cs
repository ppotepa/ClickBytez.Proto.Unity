using System;
using System.Collections.Generic;

namespace ClickBytez.Tools.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<TObjectType>(this IEnumerable<TObjectType> @this, Action<TObjectType> action)
        {
            IEnumerator<TObjectType> enumerator = @this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                action(enumerator.Current);
            }
        }
    }
}
