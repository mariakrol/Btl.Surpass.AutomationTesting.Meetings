using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.BaseConstructions
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class B_Switch
    {
        [Test]
        [TestCase(DayOfWeek.Friday)]
        [TestCase(DayOfWeek.Monday)]
        public static void A_SwitchByEnum(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Friday:
                {
                    Trace.TraceInformation("I get Friday!");
                    break;
                }
                case DayOfWeek.Saturday:
                {
                    Trace.TraceInformation("I get Saturday!");
                    break;
                }
                default:
                {
                    Trace.TraceInformation("I do not know, what I get!");
                    break;
                }
            }
        }
    }
}