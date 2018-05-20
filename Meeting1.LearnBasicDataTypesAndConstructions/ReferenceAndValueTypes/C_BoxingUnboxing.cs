using System;
using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable UnusedVariable
// ReSharper disable RedundantCast

namespace Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class C_BoxingUnboxing
    {
        /// <summary>
        /// If for some reason we had to convert a value type to reference type,
        /// we use the mechanism of boxing.
        /// It means, that we 'box' our value type to an object.
        /// When we need to get our value back from a box,
        /// we have to perform reverse operation. 
        /// Mechanism for extraction of a value type from a reference type is called unboxing.
        /// It is important, that you can get from a box exactly
        /// the same thing, what you put there.
        /// That's why, if you need to transform your value,
        /// you need to unbox in firstly.
        /// </summary>
        [Test]
        public static void A_UnboxingToUnexpectedType()
        {
            int sourceInteger = 5;
            Trace.TraceInformation($"Create variable of value type. Type: int, value: {sourceInteger}");

            Trace.TraceInformation("A cast of a numeric value of type int to long type occurs successful " +
                                   "(long longFromInt = (long)sourceInteger;), without errors.");

            Action castIntToLong = () =>
            {
                long longFromInt = (long) sourceInteger;
            };
            castIntToLong
                .Should()
                .NotThrow();

            Trace.TraceInformation(
                "But if you try to box your int value (object boxedInteger = sourceInteger;) into an object;");
            object boxedInteger = sourceInteger;
            Trace.TraceInformation("And if you try to unbox it to the different type after boxing, for example, " +
                                   "long (long unboxedLong = (long)boxedInteger;).");

            Action unboxIntToLong = () =>
            {
                long unboxedLong = (long) boxedInteger;
            };
            Trace.TraceInformation("You will get a runtime exception of type InvalidCastException, " +
                                   "because you should get your int from box first, and only after it you can cast it to a long type.");
            unboxIntToLong
                .Should()
                .Throw<InvalidCastException>();

            Trace.TraceInformation("If you want to get another type after unboxing, you should perform 2 actions: " +
                                   "1 - unbox a value, 2 - cast a value (long unboxedLong = (long)(int)boxedInteger;).");
            Action unboxToIntCastToLong = () =>
            {
                long unboxedLong = (long) (int) boxedInteger;
            };
            unboxToIntCastToLong
                .Should()
                .NotThrow();
        }
    }
}