using System.Diagnostics;

namespace Meeting2.LearnOop.InheritanceSamples.Vehicles
{
    internal static class BicycleExtensions {

        public static void UpBicycleSeat(this Bicycle bicycle) => Trace.TraceInformation("Bicycle seat is upped");
    }
}