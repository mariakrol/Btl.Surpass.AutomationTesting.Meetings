using System.Diagnostics;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.BaseConstructions
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class C_ConditionalStatement
    {
        [Test]
        [TestCase(true, true)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public static void A_ConditionalStatementWithMultipleConditions(bool oneCondition, bool otherCondition)
        {
            if (oneCondition)
            {
                Trace.TraceInformation("In the first branch of conditional statement.");
            }
            else if (otherCondition)
            {
                Trace.TraceInformation("In the second branch of conditional statement.");
            }
            else
            {
                Trace.TraceInformation("In the last branch.");
            }
        }
    }
}