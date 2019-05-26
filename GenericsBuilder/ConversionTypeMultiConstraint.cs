using System;
using System.IO;

namespace GenericsBuilder
{
    //class InvalidConversionTypeConstraint<T> where T : StringBuilder
    //{
    // 'StringBuilder' is not a valid constraint. 
    // A type used as a constraint must be an interface, a non-sealed class or a type parameter.
    //}



    //class ConversionTypeMultiConstraint<T> where T : Student, Stream, IAccountState, IFormattable //Invalid
    // ConversionType with MultiConstraints can have multiple interfaces but only 1 class

    class ConversionTypeMultiConstraint<T> where T : Stream, IAccountState, IFormattable
    {

    }

}
