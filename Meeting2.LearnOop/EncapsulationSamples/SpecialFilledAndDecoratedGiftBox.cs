using System;

namespace Meeting2.LearnOop.EncapsulationSamples
{
    internal class SpecialFilledAndDecoratedGiftBox
    {
        public SpecialFilledAndDecoratedGiftBox(int boxSideSize, string boxColor)
        {
            BoxSideSize = boxSideSize;
            Color = boxColor;
        }

        public readonly int BoxSideSize;

        private object _gift;

        // Color property protect _color field from accidental corruption.
        private string _color;
        public string Color
        {
            get => _color;

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _color = value;
                }
            }
        }

        // PackGift method protect _gift field from rewriting and filling with incorrect data.
        public void PackGift(object gift)
        {
            if (_gift != null)
            {
                throw new Exception("A gift is already packed!");
            }

            _gift = gift ?? throw new Exception("Impossible to pack nothing!");
        }

        public override string ToString() => $"Gift with {_gift}, packed to the box with side {BoxSideSize} inch of {Color} color.";
    }
}