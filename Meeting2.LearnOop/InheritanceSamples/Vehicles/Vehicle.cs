namespace Meeting2.LearnOop.InheritanceSamples.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(int speed)
        {
            _speed = speed;
        }

        // ReSharper disable once NotAccessedField.Local
        private int _speed;

        public string Color { get; set; }

        public void ChangeColor(string newColor) => Color = newColor;

        public virtual void IncreaseSpeed(int delta) => _speed += delta;

        public abstract void IndicateTurn(bool isRightTurn);
    }
}