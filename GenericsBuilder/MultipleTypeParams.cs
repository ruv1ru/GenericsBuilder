namespace GenericsBuilder
{
    class MultipleTypeParams
    {
        public static string Combine<T1, T2>(T1 x, T2 y)
        {
            return $"{x.ToString()} and {y.ToString()}"; //Any method of 'object' can also be used with type params
        }

        public static string CombineTypes<T1, T2>(T1 x, T2 y)
        {
            return $"{typeof(T1).ToString()} and {typeof(T2).ToString()}";
        }

    }

}
