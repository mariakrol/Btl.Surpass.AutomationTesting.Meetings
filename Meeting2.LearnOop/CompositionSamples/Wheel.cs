using System.Diagnostics;

namespace Meeting2.LearnOop.CompositionSamples
{
    internal class Wheel
    {

        public void Turn(bool isTurnRight)
        {
            if (isTurnRight)
            {
                Trace.TraceInformation("Turn wheel right");
                return;
            }

            Trace.TraceInformation("Turn wheel left");
        }
    }
}