using System;

namespace Meeting2.LearnOop.InheritanceSamples
{
    internal sealed class Bicycle : Vehicle
    {
        public Bicycle(int speed) : base(speed)
        {
        }

        public override void IndicateTurn(bool isRightTurn)
        {
            if (isRightTurn)
            {
                Console.WriteLine("Up Right arm");
                return;
            }


            Console.WriteLine("Up left arm");
        }

        public new void ChangeColor(string color)
        {
            Color = "abracadabra";
        }
    }

    //internal class MotoBicycle : Bicycle
    //{
    //}
}