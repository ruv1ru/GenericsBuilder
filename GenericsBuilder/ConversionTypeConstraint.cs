namespace GenericsBuilder
{
    class ConversionTypeConstraint<T, U> where T : U
    {
        // example of using another generic type as a constraint 
        // type argument provided for 'T' must be a class derived from type argument rpovided for 'U'
    }

}
