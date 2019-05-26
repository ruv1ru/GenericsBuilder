namespace GenericsBuilder
{
    struct RefTypeConstraintStruct<T> where T : class
    {
        //function can use '==' or '!=' since 'T' is a reference type
        public static bool IsEqual(T x, T y) => x == y;

    }

}
