using System;
using System.Diagnostics;

namespace Meeting2.LearnOop.InheritanceSamples.Vehicles
{
    // If you uncomment code below, you will got an error: 'CS0509  'Trike': cannot derive from sealed type 'Bicycle''
    // Because Bicycle is a sealed class and nothing can derive it
    //
    //internal class Trike : Bicycle
    //{
    //    public Trike(int speed) : base(speed)
    //    {
    //    }
    //}

    internal sealed class Bicycle : Vehicle
    {
        public Bicycle(int speed) : base(speed)
        {
        }

        public override void IndicateTurn(bool isRightTurn) => Trace.TraceInformation(isRightTurn ? "Up Right arm" : "Up left arm");
    }
}