using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.Strings
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class C_MutationsOfStrings
    {
        [Test]
        public static void A_ChangeString()
        {
            Trace.TraceInformation("Strings are immutable in C#. That's why once created, " +
                                   "string could not be changed. You can change its value, " +
                                   "but it will be a completely new string. No matter it is a reference type, new string which is created based on existing - will be new.");

            Trace.TraceInformation("If you will create a string, then create a new one from this: ");
            Trace.TraceInformation("\tstring sourceString = \"Hello\";");
            Trace.TraceInformation("\tstring newstringcreatedWithValueOfSource = sourceString;");
            Trace.TraceInformation("And then if you will change value of the source string:");
            Trace.TraceInformation("\tsourceString += \", World!\";");
            string sourceString = "Hello";
            string newStringCreatedWithValueOfSource = sourceString;
            sourceString += ", World!"; //a new string is created here

            Trace.TraceInformation("Your string will not be modified, because it is not referenced to the source. " +
                                   $"source = '{sourceString}', new string = '{newStringCreatedWithValueOfSource}';");
            newStringCreatedWithValueOfSource
                .Should()
                .NotBe(sourceString);

            ReferenceEquals(newStringCreatedWithValueOfSource, sourceString)
                .Should()
                .BeFalse();
        }
    }
}