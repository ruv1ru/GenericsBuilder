namespace GenericsBuilder
{
    class ValueTypeConstraintClass<T> where T : struct
    {
        // Since 'T' must be a struct type following function can not use '==' or '!='
        // in order to compare 2 objects of type 'T'
        // Operator '==' cannot be applied to operands of type 'T' and 'T'
        //public static bool IsEqual(T x, T y) => x == y;
        
    }

}
