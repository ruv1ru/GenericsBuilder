namespace GenericsBuilder
{
    class GenericStack<T> // T is the 'parameter type' that should be filled by the cosumer of generic type
    {
        private T[] array = new T[5000];

        private int index = 0; 

        public T this [int index] => array[index]; // indexers can use 'T' but cannot introduce new 'T'

        public void Push(T value) // Push is not a generic method but a method in a generic class
        {
            array[index++] = value;
        }

        public T Pop()
        {
            return array[--index];
        }


    }

}
