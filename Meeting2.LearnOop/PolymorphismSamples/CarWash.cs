using System.Diagnostics;
using Meeting2.LearnOop.InheritanceSamples.Vehicles;

namespace Meeting2.LearnOop.PolymorphismSamples
{
    internal class CarWash
    {
        public void Wash(Vehicle vehicle)
            => Trace.TraceInformation($"Done! Vehicle: {vehicle}");
    }
}