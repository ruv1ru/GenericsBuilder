using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace GenericsBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            // simple implimnetation of generic stack
            var stack = new GenericStack<int>();
            stack.Push(888);
            stack.Push(999);
            Console.WriteLine(stack.Pop());

            Console.WriteLine(stack[0]);

            //Generics can be used without explicitly specifying the type
            //As long as type be inferred from the usage
            int x = 88;
            int y = 77;
            GenericSwap.Swap(ref x, ref y);
            Console.WriteLine(x);
            Console.WriteLine(y);
            
            //The type arguments for method 'GenericSwap.SwapInts<T>(ref int, ref int)' 
            //cannot be inferred from the usage. Try specifying the type arguments explicitly.
            //GenericSwap.SwapInts(ref x, ref y);


            decimal t1 = 323;
            double t2 = 33;
            // Since parameters implicitly specify types, T1 and T2 does not need to be explicitly defined 
            Console.WriteLine(MultipleTypeParams.Combine(t1, t2));
            Console.WriteLine(MultipleTypeParams.CombineTypes(t1, t2));


            var array = new int[3];
            array[0] = 55;
            Console.WriteLine(array[0]);
            GenericDefaultValue.Zap(array);
            Console.WriteLine(array[0]);

            var accountList = new Account1[3];
            accountList[0] = new Account1();
            Console.WriteLine(accountList[0]); 
            GenericDefaultValue.Zap(accountList); // Will set value to NULL
            Console.WriteLine(accountList[0] == null);

            var account1 = new Account1(); //Account1 impliments both AccountFrozen and IAccountState
            var account2 = new Account2(); //Account2 does not impliment IAccountState 

            new GenericMultiConstraints<Account1>().Deposit();

            //The type 'GenericsBuilder.Account2' cannot be used as type parameter 'TState' 
            //in the generic type or method 'GenericMultiConstraints<TState>'.
            //There is no implicit reference conversion from 'GenericsBuilder.Account2' to 'GenericsBuilder.IAccountState'.
            //new GenericMultiConstraints<Account2>().Deposit();
            

            GenericMethodWithConstraints.ProcessStruct<int>();

            //The type 'string' must be a non-nullable value type in order to use it as parameter 'TKey' 
            //in the generic type or method 'GenericMethodWithConstraints.ProcessStruct<TKey>()'
            //GenericMethodWithConstraints.ProcessStruct<string>();

            // 'Max' is a generic method with IComaparable constraint
            // All types passed into this method should impliment IComaparable<T>
            // This allows the method to use 'CompareTo' method with the type parameter
            var maxString = GenericMethodWithConstraints.Max("home1", "home2");

            Console.WriteLine(maxString);

            var maxInt = GenericMethodWithConstraints.Max(1, 2);

            Console.WriteLine(maxInt);


            var home1 = new Home() { Area = 500 };
            var home2 = new Home() { Area = 200 };


            var homeWithMaxArea = GenericMethodWithConstraints.Max(home1, home2);

            Console.WriteLine(homeWithMaxArea.Area);

            /*
            
                var students = new Students();

                Console.WriteLine(students[0].Name);
                Console.WriteLine(students[0].Age);
                Console.WriteLine(students[2].Name);
             */

            //var dic = new Dictionary<int, int>();


            // Generic types can be overloaded within the same namesapce based on the number of type arguments 
            var newOverloadedGenericType = new OverloadType<int>();
            var newOverloadedGenericType2 = new OverloadType<int, string>();
            var newOverloadedGenericType3 = new OverloadType<int, int, int>();
            

            //Usig generic extension method with generic delegate to convert from one type to another
            string number = "99";

            var intNumber = number.ConvertToType(TypeConverter.ConvertStringToInt);
            Console.WriteLine(intNumber);

            // Array extension method with generic delegates to convert array type
            string[] intArray = new string[]{ "false", "true", "0", "1" };

            bool[] resultArray = intArray.ConvertArrayToType(TypeConverter.ConvertStringToBool);

            for(int i = 0; i < resultArray.Length; i++)
            {
                Console.WriteLine(resultArray[i]);
            }

            // RefTypeConstraintStruct is a generic struct with constraints 
            //that only takes 'reference' type as the type argument 
            var refTypeStruct1 = new RefTypeConstraintStruct<Student>();
            var refTypeStruct2 = new RefTypeConstraintStruct<int[]>();
            //GenericsBuilder.RefTypeConstraintStruct`1[GenericsBuilder.Student]
            //GenericsBuilder.RefTypeConstraintStruct`1[System.Int32[]]
            Console.WriteLine(refTypeStruct1.ToString());
            Console.WriteLine(refTypeStruct2.ToString());
            
            //The type 'int' must be a reference type in order to use it as parameter 'T' in the generic type or 
            //method 'RefTypeConstraintStruct<T>'
            //var refTypeStruct3 = new RefTypeConstraintStruct<int>();

            var valTypeConstraint1 = new ValueTypeConstraintClass<AccountType>();

            //The type 'Student' must be a non-nullable value type in order to use it as parameter 'T'
            //var valTypeConstraint2 = new ValueTypeConstraintClass<Student>();

            // generic classes with constructor type constraints require a class that has 
            //implicit or explicit parameterless constructor 
            var ctorContraint1 = new ConstructorTypeConstraint<ClassWithParamlessCtor>();

            //'ClassWithExplicitCtor' must be a non-abstract type with a public parameterless constructor in order to use it as parameter 'T' 
            //in the generic type or method 'ConstructorTypeConstraint<T>'
            //var ctorContraint2 = new ConstructorTypeConstraint<ClassWithExplicitCtor>();

            // type argument must be a class derived from abstract class 'Stream'
            var stream1 = new ConversionTypeConstraint<FileStream>();

            // Invalid argement violating conversion type constraint 
            //The type 'System.Text.StringBuilder' cannot be used as type parameter 'T' 
            //in the generic type or method 'ConversionTypeConstraint<T>'. 
            //There is no implicit reference conversion from 'System.Text.StringBuilder' to 'System.IO.Stream'
            //var stream2 = new ConversionTypeConstraint<StringBuilder>();


            var multiConvert = new ConversionTypeConstraint<FileStream, Stream>();

            //use of unbound generic type without the use of arguments
            Type type1 = typeof(UnboundType<>);
            Console.WriteLine(type1.FullName); //GenericsBuilder.UnboundType`1
            // comma added to specify that this is the unbound type with 2 type paramaeters 
            Type type2 = typeof(UnboundType<,>);
            Console.WriteLine(type2.FullName); //GenericsBuilder.UnboundType`2

            Type type3 = typeof(UnboundType<int,double>);
            //GenericsBuilder.UnboundType`2
            //[[System.Int32, System.Private.CoreLib, Version=4.0.0.0],
            //[System.Double, System.Private.CoreLib, Version=4.0.0.0]
            Console.WriteLine(type3.FullName); 


            var refAndStruct = new MultiConstraintsRef<ICusRefType, CusStruct>();











        }

    }


    interface ICusRefType {} //Reference type 
    struct CusStruct : ICusRefType{} //Struct can implement an interface

    class MultiConstraintsRef<T, U> where T: class where U: struct, T {
        //T must be a reference type
        //U must be a value type
        //However U must also be of type T (which must be a reference type)
        //How can U be a struct and a reference type both at the same time
        //Type parameter can not be struct and a class at the same time
        //However struct type can impliment an interface
        //An interface is considered to as an reference type
        //therefore this is a valid multiple conrtaint 
    }

    class UnboundType<T>{}
    class UnboundType<T1, T2>{}



    class ConversionTypeConstraint<T> where T : Stream
    {
        // type argument provided for 'T' must be a class derived from abstract class 'Stream'
    }

}
