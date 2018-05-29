using System.Diagnostics;

namespace Meeting2.LearnOop.InheritanceSamples.Vehicles
{
    internal class MotorVehicle : Vehicle
    {
        public MotorVehicle(int speed) : base(speed)
        {
        }

        public override int IncreaseSpeed(int delta) => base.IncreaseSpeed(delta * 2);

        public override void IndicateTurn(bool isRightTurn)
        {
            if (isRightTurn)
            {
                Trace.TraceInformation("Indicate by right lamp");
                return;
            }
            Trace.TraceInformation("Indicate by left lamp");
        }
    }
}