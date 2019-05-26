using System;
using System.Collections.Generic;
using System.Linq;
namespace GenericsBuilder
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetKCombs<T>(this IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => !o.Equals(t.Last())),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public static IEnumerable<(float x, float y)> Intersect(this IEnumerable<(float x, float y)> list, IEnumerable<(float x, float y)> other)
        {
            var intersect = new List<(float x, float y)>();

            foreach(var otherItem in other){
               
                foreach(var thisItem in list){
                    

                    if(thisItem.x == otherItem.x && thisItem.y == otherItem.y)
                    {
                        intersect.Add(thisItem);
                    }

                }
                
            }

            return intersect;

            
        }
    }
}