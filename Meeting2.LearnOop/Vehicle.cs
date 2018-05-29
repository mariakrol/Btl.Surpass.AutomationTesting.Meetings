using System;

namespace Meeting2.LearnOop
{
    internal abstract class Vehicle
    {
        private int _speed;

        private static readonly int MaxWeight;

        private string _currentColor;

        public string Color
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentColor))
                {
                    return _currentColor;
                }

                throw new Exception("Is not colored.");
            }
            set
            {
                if (_currentColor == null || !_currentColor.Equals(value))
                {
                    _currentColor = value;
                }
            }
        }

        static Vehicle()
        {
            MaxWeight = 1000;
        }

        protected Vehicle(int speed)
        {
            _speed = speed;
        }

        public void ChangeColor(string newColor)
        {
            Color = newColor;
        }

        public virtual int IncreaseSpeed(int delta)
        {
            _speed += delta;

            return _speed;
        }

        public abstract void IndicateTurn(bool isRightTurn);

        public static int GetMaxWeight() => MaxWeight;
    }
}
