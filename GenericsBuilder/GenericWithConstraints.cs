namespace GenericsBuilder
{
    class GenericWithConstraints<T> where T: new()
    {
        public T GetNewInstance()
        {
            return new T();
        }

        
        public void GetNewInstanceWithArguments()
        {
            //'T': cannot provide arguments when creating an instance of a variable type (CS0417)
            //var instance = new T("constructorparam");
        }


        
        //public int CastToInt<TElement> (TElement x) => (int)x; //Cannot convert type 'TElement' to 'int'
        public int CastToInt<TElement> (TElement x) => (int)(object)x;

        public double? CastToDouble<TKey> (TKey key)
        {
            //if(key is double) return (double)key; //Cannot convert type 'TKey' to 'double'


            return key as double?;

            //var list = new List<string>();
        }
        

    }
    
    


}
