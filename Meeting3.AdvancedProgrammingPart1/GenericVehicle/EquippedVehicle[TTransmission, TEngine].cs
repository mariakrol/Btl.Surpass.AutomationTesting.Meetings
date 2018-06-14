using System.Diagnostics;
using Meeting2.LearnOop.InheritanceSamples.Vehicles;
// ReSharper disable UnusedTypeParameter

namespace Meeting3.AdvancedProgrammingPart1.GenericVehicle
{
    internal class EquippedVehicle<TTransmission, TEngine> : Vehicle
        where TTransmission : ITransmission
        where TEngine : Engine
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