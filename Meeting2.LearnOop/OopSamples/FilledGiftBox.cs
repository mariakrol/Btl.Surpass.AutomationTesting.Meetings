using System.Diagnostics;

namespace Meeting2.LearnOop.OopSamples
{
    internal class FilledGiftBox
    {
        public FilledGiftBox(object gift)
        {
            Trace.TraceInformation("In the constructor with one parameter - 'gift'.");
            Gift = gift;
        }

        public object Gift { get; }
    }
}