namespace Meeting2.LearnOop.InheritanceSamples
{
    internal class MotorVehicle : Vehicle
    {
        private Wheel[] Wheekles { get; set; }

        private Motor VehicleMotor;

        public MotorVehicle(int speed) : base(speed)
        {
            VehicleMotor = new Motor();
        }

        public override int IncreaseSpeed(int delta)
        {
            return base.IncreaseSpeed(delta * 2);
        }

        protected class Motor
        {
            public int MaxSpeed { get; set; }
        }

        public override void IndicateTurn(bool isRightTurn)
        {
            throw new System.NotImplementedException();
        }
    }
}