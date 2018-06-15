using FluentAssertions;
using NUnit.Framework;

namespace Meeting4.AdvancedProgrammingPart2
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class A_Delegates
    {

        /// <summary>
        /// The main thing, you can see in the sample: when we call an instance of delegate IntOperation, a method
        /// which is referenced by this delegate is called. 
        /// That's why, the call of a method is checked at runtime, not at compile time.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        [TestCase(5, 10)]
        public static void A_DelegatecontainReferenceOnMethod(int i, int j)
        {

            // Here ReSharper tells us, that it is redundant call delegate's constructor, because we can simply assign the method
            // But we want to see this syntax now
            // ReSharper disable once RedundantDelegateCreation
            IntOperation operationWithIntegers = new IntOperation(SimpleCalculator.Add);

            var resultSum = operationWithIntegers(i, j);
            resultSum
                .Should()
                .Be(i + j);


            operationWithIntegers = SimpleCalculator.Multiply;

            var resultProduct = operationWithIntegers(i, j);
            resultProduct
                .Should()
                .Be(i * j);
        }

    }
}
