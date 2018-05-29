namespace Meeting2.LearnOop.InheritanceSamples.Vehicles
{
    internal abstract class Vehicle
    {
        protected Vehicle(int speed)
        {
            _speed = speed;
        }

        private int _speed;

        public string Color { get; set; }

        public void ChangeColor(string newColor) => Color = newColor;

        public virtual int IncreaseSpeed(int delta)
        {
            _speed += delta;
            return _speed;
        }

        public abstract void IndicateTurn(bool isRightTurn);
    }
}