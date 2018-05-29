namespace Meeting2.LearnOop.InheritanceSamples.Vehicles
{
    internal class Car : MotorVehicle
    {
        public Car(int speed) : base(speed)
        {
        }

        public new void ChangeColor(string newColor) => Color = "abra-cadabra";

        public override string ToString() => $"Car of {Color} color";
    }
}