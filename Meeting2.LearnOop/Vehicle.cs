namespace Meeting2.LearnOop
{
    internal class Vehicle
    {
        private int _speed;

        private static readonly int MaxWeight;

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
