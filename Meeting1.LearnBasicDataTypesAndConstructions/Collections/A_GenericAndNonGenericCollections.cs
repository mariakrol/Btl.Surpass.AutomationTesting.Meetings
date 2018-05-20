using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.Collections
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class A_GenericAndNonGenericCollections
    {
        [Test]
        public static void A_UseAppropriateCollection()
        {
            string[] strings = {"one", "two", "three"};

            Trace.TraceInformation(
                "If indexes are redundant for specific actions and items will be read, IReadOnlyCollection is target type.");
            PrintStrigs(strings);

            Trace.TraceInformation(
                "If it is required to get an access to the item by its index, but only o read, IReadOnlyList is target type");
            PrintItem(strings, 1);
        }

        private static void PrintStrigs(IReadOnlyCollection<string> strings) =>
            Trace.TraceInformation(string.Join("; ", strings));

        private static void PrintItem(IReadOnlyList<string> strings, int index) =>
            Trace.TraceInformation(strings[index]);
    }
}