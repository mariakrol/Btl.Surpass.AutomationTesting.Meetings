using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Meeting1.LearnBasicDataTypesAndConstructions
{
    internal static class Utilities
    {
        public static string CreateString<TValue>(TValue value)
        {
            if (!(value is string) && value is IEnumerable collection)
            {
                var itemsStrings = new List<string>();

                foreach (var item in collection)
                {
                    itemsStrings.Add(item.ToString());
                }

                return string.Join(", ", itemsStrings);
            }

            return value.ToString();
        }

        public static void PrintStringCharsByIndexes(string @string)
        {
            string header = string.Empty;
            string stringChars = string.Empty;

            for (int i = 0; i < @string.Length; i++)
            {
                header += $"|{i}";
                stringChars += $"|{@string[i]}{(i > 9 ? " " : string.Empty)}";
            }
            Trace.TraceInformation($"{header}|");
            Trace.TraceInformation($"{stringChars}|");
        }
    }
}