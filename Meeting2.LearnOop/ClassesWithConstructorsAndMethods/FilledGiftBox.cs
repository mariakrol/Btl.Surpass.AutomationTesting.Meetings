using System.Diagnostics;

namespace Meeting2.LearnOop.ClassesWithConstructors
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