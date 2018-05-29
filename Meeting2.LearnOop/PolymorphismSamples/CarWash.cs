using System;
using Meeting2.LearnOop.InheritanceSamples.Vehicles;

namespace Meeting2.LearnOop.PolymorphismSamples
{
    internal class CarWash
    {
        public void Wash(Vehicle vehicle)
        {
            Console.WriteLine($"Done! Vehicle: {vehicle}");
        }
    }
}