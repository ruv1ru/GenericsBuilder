namespace GenericsBuilder
{
    class GenericDefaultValue
    {
        public static void Zap<T>(T[] array)
        {
            for(int i = 0; i < array.Length; i++)
                array[i] = default(T); //Set default value of the generic type
        }
    }

}
