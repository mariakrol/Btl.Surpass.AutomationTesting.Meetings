using System.Diagnostics;
using NUnit.Framework;

namespace Meeting4.AdvancedProgrammingPart2
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class B_Functions
    {
        [Test]
        public static void A_CallAnonymousMethod()
        {
            // ReSharper disable once ConvertToLocalFunction
            Sum getSumOfIntegers = delegate(int[] numbers)
            {
                int sum = 0;
                foreach (var number in numbers)
                {
                    sum += number;
                }
                return sum;
            };

            var sumOfIntegers = getSumOfIntegers(new[] {1, 5, 50, 1000});

            Trace.TraceInformation(sumOfIntegers.ToString());
        }
        
        [Test]
        public static void B_CallLambdaFunctions()
        {
            // ReSharper disable once ConvertToLocalFunction
            Sum getSumOfIntegers = numbers =>
            {
                int sum = 0;
                foreach (var number in numbers)
                {
                    sum += number;
                }
                return sum;
            };

            var sumOfIntegers = getSumOfIntegers(new[] {1, 5, 50, 1000});

            Trace.TraceInformation(sumOfIntegers.ToString());
        }

        [Test]
        public static void C_CallLocalFunctions()
        {
            int GetSumOfIntegers(int[] numbers)
            {
                int sum = 0;
                foreach (var number in numbers)
                {
                    sum += number;
                }
                return sum;
            }

            var sumOfIntegers = GetSumOfIntegers(new[] {1, 5, 50, 1000});

            Trace.TraceInformation(sumOfIntegers.ToString());
        }
    }
}