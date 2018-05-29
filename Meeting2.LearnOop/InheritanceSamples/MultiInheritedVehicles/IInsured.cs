using System;

namespace Meeting2.LearnOop.InheritanceSamples.MultiInheritedVehicles
{
    internal interface IInsured
    {
        DateTime Validity { get; set; }

        int SumInsured { get; set; }
    }
}