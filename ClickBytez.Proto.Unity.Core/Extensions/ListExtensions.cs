using System;
using System.Collections.Generic;

namespace ClickBytez.Proto.Unity.Core.Extensions
{
    public static class ListExtensions
    {
        public static void ForEach<TObjectType>(this List<TObjectType> @this, Action<TObjectType, int> action)
        {
            int index = 0;
            List<TObjectType>.Enumerator enumerator = @this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                action(enumerator.Current, index++);
            }
        }
    }
}
