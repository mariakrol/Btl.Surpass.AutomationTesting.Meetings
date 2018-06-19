using System;
using System.Diagnostics;

namespace Meeting4.AdvancedProgrammingPart2.OperationsWithArray
{
    internal static class ArrayEvaluator
    {
        public static void PrintArray(int[] array)
        {
            Trace.TraceInformation($"Array: '{string.Join("; ", array)}'");
        }

        public static void SortAscending(int[] array)
        {
            Trace.TraceInformation("Sort array in ascending order.");
            Array.Sort(array);
        }

        public static void SortDescending(int[] array)
        {
            Trace.TraceInformation("Sort array in descending order.");
            Array.Sort(array);
            Array.Reverse(array);
        }
    }
}
