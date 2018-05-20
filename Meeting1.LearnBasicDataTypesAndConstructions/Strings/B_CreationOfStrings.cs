using System;
using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.Strings
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class B_CreationOfStrings
    {
        [Test]
        public static void A_CreateNewStringByPartsUsingConcatenation()
        {
            Trace.TraceInformation(
                "You can use concatenation by plus sign to get a string, which consists of several parts:");
            Trace.TraceInformation(
                "string concatenadetString = \"I\" + \" \" + \"created\" + \" by concatenating of several \" + \"parts\";");
            var concatenatedStringByPlus = "I" + " " + "created" + " by concatenating of several " + "parts";

            Trace.TraceInformation(
                $"Then your string will be assembled to the single one: '{concatenatedStringByPlus}'.");

            Trace.TraceInformation(
                "You also can use concatenation by string.Concat method to get a string, which consists of several parts:");
            Trace.TraceInformation(
                "string concatenadetString = string.Concat(\"I\", \" \", \"created\", \" \", \"by concatenating of several \", \"parts\");");
            var concatenatedStringByMethod =
                string.Concat("I", " ", "created", " ", "by concatenating of several ", "parts");

            Trace.TraceInformation(
                $"Then your string will be assembled to the single one again: '{concatenatedStringByMethod}'.");

            Trace.TraceInformation("And both strings are exactly the same.");
            concatenatedStringByPlus
                .Should()
                .Be(concatenatedStringByMethod);
        }

        [Test]
        public static void B_CreateNewStringAsFormattedString()
        {
            Trace.TraceInformation(
                "You can use formating of string to get a string, which consists of several parts:");
            Trace.TraceInformation(
                "string formatedString = string.Format(\"I{0} by {1} with several {2}\", \"created\", \"formatting\", \"parameters\");");
            // ReSharper disable once UseStringInterpolation
            var formatedString = string.Format("I {0} by {1} with several {2}", "created", "formatting", "parameters");

            Trace.TraceInformation($"Then your string will be assembled to the single one: '{formatedString}'.");
            Trace.TraceInformation("And it matches with the string, initialized without format.");
            formatedString
                .Should()
                .Be("I created by formatting with several parameters");
        }

        [Test]
        public static void C_CreateNewStringUsingStringInterpolation()
        {
            Trace.TraceInformation(
                "You can use interpolation of string get a string, which consists of several parts:");
            Trace.TraceInformation(
                "string interpolatedString = $\"I interpolated string with date parameter: {DateTime.Now:D}\";");
            var interpolationStringParameter = "I interpolated string with date parameter";
            var interpolationDateParameter = new DateTime(2015, 5, 1);
            var interpolatedString = $"{interpolationStringParameter}: {interpolationDateParameter:D}";

            Trace.TraceInformation($"Then your string will be assembled to the single one: '{interpolatedString}'.");
            Trace.TraceInformation(
                "And due to formating of interpolation parameter with 'D' format variant, you get date in format: 'Day of week, month D, YYYY'.");
            Trace.TraceInformation(
                "And it contain string part and date, which is casted to string with long date format.");

            interpolatedString
                .Should()
                .Contain(interpolationStringParameter)
                .And
                .Contain(interpolationDateParameter.ToLongDateString());
        }

        [Test]
        public static void D_CreateNewStringFromArray()
        {
            Trace.TraceInformation("You can join several strings to the single one:");
            Trace.TraceInformation(
                "string joinedString = string.Join(\" \", new[] {\"I\", \"created\", \"from\", \"an\", \"array\"});");

            string[] arrayOfStrings = {"I", "created", "from", "an", "array"};
            var separator = " ";
            string joinedString = string.Join(separator, arrayOfStrings);

            Trace.TraceInformation(
                "Then the string will contain each joined string and separators between each of them.");

            joinedString
                .Should()
                .ContainAll(arrayOfStrings)
                .And
                .Contain(separator);
        }
    }
}