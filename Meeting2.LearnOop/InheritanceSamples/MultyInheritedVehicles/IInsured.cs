using System;

namespace Meeting2.LearnOop.InheritanceSamples.MultyInheritedVehicles
{
    internal interface IInsured
    {
        DateTime Validity { get; set; }

        int SumInsured { get; set; }
    }
}