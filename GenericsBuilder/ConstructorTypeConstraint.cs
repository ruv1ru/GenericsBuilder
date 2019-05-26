namespace GenericsBuilder
{
    class ConstructorTypeConstraint<T> where T : new(){
        static T GenericFactory(){
            return new T();
        }
    }

}
