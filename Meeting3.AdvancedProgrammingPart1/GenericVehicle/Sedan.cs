namespace Meeting3.AdvancedProgrammingPart1.GenericVehicle
{
    internal class Sedan<TTransmission> : EquippedVehicle<TTransmission, GasEngine>
        where TTransmission : ITransmission
    {
        public Sedan(int speed) : base(speed)
        {
        }
    }
}