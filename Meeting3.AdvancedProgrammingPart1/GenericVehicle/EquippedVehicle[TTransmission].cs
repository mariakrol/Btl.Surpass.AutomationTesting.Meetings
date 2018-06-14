using System.Diagnostics;
using Meeting2.LearnOop.InheritanceSamples.Vehicles;
// ReSharper disable UnusedTypeParameter

namespace Meeting3.AdvancedProgrammingPart1.GenericVehicle
{
    internal class EquippedVehicle<TTransmission> : Vehicle
        where TTransmission : ITransmission
    {
        public EquippedVehicle(int speed) : base(speed)
        {
        }

        public override void IndicateTurn(bool isRightTurn)
        {
            Trace.TraceInformation(isRightTurn ? "Turn right lamp" : "Turn left lamp");
        }
    }
}
