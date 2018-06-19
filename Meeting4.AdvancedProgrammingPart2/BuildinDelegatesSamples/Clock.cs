using System;
using System.Diagnostics;

namespace Meeting4.AdvancedProgrammingPart2.BuildinDelegatesSamples
{
    public static class Clock
    {
        public static void PrintCurrentTime() => Trace.TraceInformation(DateTime.Now.ToLongDateString());
    }
}