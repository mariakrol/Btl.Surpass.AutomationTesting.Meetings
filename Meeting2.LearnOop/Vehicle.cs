using System;

namespace Meeting2.LearnOop
{
    internal class Vehicle
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
                if (!_currentColor.Equals(value))
                {
                    _currentColor = value;
                }
            }
        }

        static Vehicle()
        {
            MaxWeight = 1000;
        }

        public Vehicle(int speed)
        {
            _speed = speed;
        }

        public int IncreaseSpeed(int delta)
        {
            _speed += delta;

            return _speed;
        }

        public static int GetMaxWeight() => MaxWeight;
    }
}
