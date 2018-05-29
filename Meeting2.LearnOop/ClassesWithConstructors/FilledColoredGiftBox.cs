using System.Diagnostics;

namespace Meeting2.LearnOop.ClassesWithConstructors
{
    internal class FilledColoredGiftBox
    {
        public FilledColoredGiftBox(object gift)
        {
            Gift = gift;
        }

        public FilledColoredGiftBox(object gift, string boxColor) : this (gift)
        {
            Trace.TraceInformation("In the constructor with two parameters - 'gift', 'box color'.");

            Color = boxColor;
        }

        public object Gift { get; }

        public string Color { get; } = "Purple";
    }
}