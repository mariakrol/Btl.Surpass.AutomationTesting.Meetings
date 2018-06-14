using System.Diagnostics;

namespace Meeting3.AdvancedProgrammingPart1.GenericVehicle
{
    internal class Sedan<TTransmission> : EquippedVehicle<TTransmission, GasEngine>
        where TTransmission : ITransmission
    {
        public Sedan(int speed) : base(speed)
        {
            Transmission = default(TTransmission);
        }

        public Sedan(int speed, TTransmission transmission) : base(speed)
        {
            Transmission = transmission;
        }

        public TTransmission Transmission { get; private set; }

        public void ChangeTransmission(TTransmission newTransmission)
        {
            Transmission = newTransmission;
            Trace.TraceInformation("Transmission is changed");
        }
    }
}