using System;
using System.Collections.Generic;
using System.Linq;

namespace CoperAlgoLib.Data
{
    public static class EnumerableHelpers
    {
        public static IEnumerable<T> ReverseEx<T>(this IEnumerable<T> coll)
        {
            // if coll is indexable
            if (coll is IList<T> quick)
                for (int i = quick.Count - 1; i >= 0; --i)
                    yield return quick[i];
            else
                foreach (var item in coll.Reverse())
                    yield return item;
        }
    }
}
