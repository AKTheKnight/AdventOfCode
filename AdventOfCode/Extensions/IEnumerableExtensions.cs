using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace uk.co.aktheknight.AdventOfCode.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TResult> Cycle<TSource, TResult>
        (this IEnumerable<TSource> source,
            Func<TSource, TResult> projection)
        {
            var iterator = source.GetEnumerator();
            while (true)
            {
                if (!iterator.MoveNext())
                    iterator = source.GetEnumerator();
                while (iterator.MoveNext())
                {
                    yield return projection(iterator.Current);
                }
            }

            /*using (var iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    yield break;
                }
                TSource previous = iterator.Current;
                while (iterator.MoveNext())
                {
                    yield return projection(previous, iterator.Current);
                    previous = iterator.Current;
                    
                }
            }*/
        }

        public static IEnumerable<T> Cycle<T>
            (this IEnumerable<T> source)
        {
            var iterator = source.GetEnumerator();
            while (true)
            {
                if (iterator.MoveNext())
                    yield return iterator.Current;
                else
                    iterator = source.GetEnumerator();
            }
        }
        
        public static IEnumerable<T> AlternateElements<T>(this IEnumerable<T> source)  
        {  
  
            int i = 0;  
  
            foreach (var element in source)  
            {  
                if (i % 2 == 0)
                {
                    yield return element;
                }  
                i++;  
            }
        }
    }
}