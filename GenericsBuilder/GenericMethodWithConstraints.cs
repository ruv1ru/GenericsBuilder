using System;

namespace GenericsBuilder
{
    class GenericMethodWithConstraints
    {
        
        public static void ProcessStruct<TKey>() where TKey: struct //Constraints can also be added to generic methods
        {

        }

        public static T Max<T>(T x, T y) where T : IComparable<T>
        {
            return x.CompareTo(y) > 0 ? x : y;
        }

    }
    
    


}
