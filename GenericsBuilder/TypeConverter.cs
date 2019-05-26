using System;

namespace GenericsBuilder
{
    public static class TypeConverter
    {

        public static TOutput ConvertToType<T, TOutput>(this T value, Converter<T, TOutput> converter)
        {
            //Converter<T, TOutput> converter is a 'generic delegate'
            return converter.Invoke(value);
        }
        public static TOutput[] ConvertArrayToType<T, TOutput>(this T[] value, Converter<T, TOutput> converter)
        {
            TOutput[] outputArray = new TOutput[value.Length];

            for(int i = 0; i < value.Length; i++){

                 outputArray[i] = converter.Invoke(value[i]);
            }

            return outputArray;
        }

        public static int ConvertStringToInt(string value)
        {
            return int.Parse(value);
        }

        
        public static bool ConvertStringToBool(string value)
        {
            return value == "true" || value == "True" || value == "1";
        }


    }

}
