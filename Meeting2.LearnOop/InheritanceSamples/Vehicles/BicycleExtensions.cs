using System.Diagnostics;

namespace Meeting2.LearnOop.InheritanceSamples.Vehicles
{
    internal static class BicycleExtensions
    {
        public static void PumpWheel(this Bicycle bicycle) => Trace.TraceInformation("Bicycle's wheel is pumped!");
    }
}