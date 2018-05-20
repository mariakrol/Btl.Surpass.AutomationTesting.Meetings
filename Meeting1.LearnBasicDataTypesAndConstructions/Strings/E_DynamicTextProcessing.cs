using System.Diagnostics;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.Strings
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class E_DynamicTextProcessing
    {
        [Test]
        public static void A_ObjectOfTypeStringBuilderReferenceOnTheSamePlaceAfterMutation()
        {
            Trace.TraceInformation("StringBuilder is mutable data type in C#. " +
                                   "This type created to process a big text data which can be changed multiple times");

            Trace.TraceInformation("If you will create a StringBuilder, then create a new one from this: ");
            Trace.TraceInformation("\tStringBuilder sourceStringBuilder = new StringBuilder(\"Hello\");");
            Trace.TraceInformation("\tStringBuilder newStringBuilderWithValueOfSource = sourceString;");
            Trace.TraceInformation("And then if you will change value of the source one:");
            Trace.TraceInformation("\tsourceString.Append(\", World!\");");
            StringBuilder sourceStringBuilder = new StringBuilder("Hello");
            StringBuilder newStringBuilderWithValueOfSource = sourceStringBuilder;
            sourceStringBuilder.Append(", World!");

            Trace.TraceInformation(
                "Your text will be modified, because the variable is referenced to the source object in the memory. " +
                $"source = '{sourceStringBuilder}', new string = '{newStringBuilderWithValueOfSource}';");
            newStringBuilderWithValueOfSource
                .Should()
                .Be(sourceStringBuilder);

            ReferenceEquals(newStringBuilderWithValueOfSource, sourceStringBuilder)
                .Should()
                .BeTrue();
        }
    }
}