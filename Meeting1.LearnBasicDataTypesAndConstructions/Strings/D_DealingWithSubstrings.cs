using System;
using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.Strings
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class D_DealingWithSubstrings
    {
        [Test]
        public static void A_GetSubstringByStartIndex()
        {
            Trace.TraceInformation(
                "You can get a substring from a string starting with target character, depicted by index, to the end of the string.");
            var stringWithSubstring = "String with substring";
            Trace.TraceInformation($"String: '{stringWithSubstring}', by indexes:");
            Utilities.PrintStringCharsByIndexes(stringWithSubstring);

            var startIndex = 12;
            var substring = stringWithSubstring.Substring(startIndex);

            Trace.TraceInformation($"Substring from {startIndex} index to the end: '{substring}'.");

            stringWithSubstring
                .Should()
                .EndWith(substring);

            Trace.TraceInformation($"Source string is not changed: '{stringWithSubstring}'.");
        }

        [Test]
        public static void B_GetSubstringByStartIndexAndLength()
        {
            Trace.TraceInformation(
                "You can get a substring from a string starting with target character, depicted by index, with target length.");
            var stringWithSubstring = "String with  target substring in the middle";
            Trace.TraceInformation($"String: '{stringWithSubstring}', by indexes:");
            Utilities.PrintStringCharsByIndexes(stringWithSubstring);

            var startIndex = 20;
            var length = 9;
            var substring = stringWithSubstring.Substring(startIndex, length);

            Trace.TraceInformation($"Substring from {startIndex} index with length {length}: '{substring}'.");

            stringWithSubstring
                .Should()
                .Contain(substring);

            Trace.TraceInformation($"Source string is not changed: '{stringWithSubstring}'.");
        }

        [Test]
        public static void C_GetStartIndexOfSubstring()
        {
            Trace.TraceInformation("You can get the start index of a substring in a string by its value.");
            var stringWithSubstring = "String with target substring in the middle";
            Trace.TraceInformation($"String: '{stringWithSubstring}', by indexes:");
            Utilities.PrintStringCharsByIndexes(stringWithSubstring);

            var targetSubstring = "substring";
            var substringIndex = stringWithSubstring.IndexOf(targetSubstring, StringComparison.Ordinal);

            Trace.TraceInformation(
                $"Substring '{targetSubstring}' is started at {substringIndex} in the source string.");

            stringWithSubstring
                .Substring(substringIndex, targetSubstring.Length)
                .Should()
                .Be(targetSubstring);

            Trace.TraceInformation($"Source string is not changed: '{stringWithSubstring}'.");
        }

        [Test]
        public static void D_ReplaceSubstring()
        {
            Trace.TraceInformation("You can replace a substring in a string by its value.");
            var stringWithSubstring = "String with target substring in the middle";
            Trace.TraceInformation($"String: '{stringWithSubstring}'.");

            var sourceSubstring = "target substring";
            var newSubstring = "new substring";

            var newString = stringWithSubstring.Replace(sourceSubstring, newSubstring);

            Trace.TraceInformation(
                $"New string is created based on source the one, there substring '{sourceSubstring}' is replaced with '{newSubstring}': '{newString}'");

            newString
                .Should()
                .Contain(newSubstring)
                .And
                .NotContain(sourceSubstring);

            Trace.TraceInformation($"Source string is not changed: '{stringWithSubstring}'.");
            stringWithSubstring
                .Should()
                .Contain(sourceSubstring)
                .And
                .NotContain(newSubstring);
        }
    }
}