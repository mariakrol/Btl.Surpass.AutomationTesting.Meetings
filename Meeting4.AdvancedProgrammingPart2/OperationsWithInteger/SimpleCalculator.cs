using System.Diagnostics;

namespace Meeting4.AdvancedProgrammingPart2.OperationsWithInteger
{
    internal static class SimpleCalculator
    {
        internal static int Add(int i, int j)
        {
            var sum = i + j;
            Trace.TraceInformation($"Sum of {i} and {j} is {sum}.");

            return sum;
        }

        internal static int Multiply(int i, int j)
        {
            var product = i * j;
            Trace.TraceInformation($"Product of {i} and {j} is {product}.");

            return product;
        }

        internal static int Divide(int i, int j)
        {
            var quotient = i / j;
            Trace.TraceInformation($"Quotient  of {i} and {j} is {quotient}.");

            return quotient;
        }
    }
}
