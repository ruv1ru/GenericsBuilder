namespace GenericsBuilder
{
    class GenericSwap // GenericSwap itself is not a generic class but contains a generic method
    {

        //public GenericSwap<T>(){}  //invalid since constructor cannot introduce new type parameter
        public static void Swap<T>(ref T x, ref T y) // Swap is a generic method hence <T> should be added after method name
        {
            T temp = x;
            x = y;
            y = temp;
        }

        public static void SwapInts<T>(ref int x, ref int y) where T : new() //Parameters are not of type 'T'
        {
            T type = new T(); //Other use of 'T'
            int temp = x;
            x = y;
            y = temp;
        }

    }

}
