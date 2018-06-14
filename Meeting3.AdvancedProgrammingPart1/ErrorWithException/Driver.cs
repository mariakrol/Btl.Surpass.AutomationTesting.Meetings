using Meeting3.AdvancedProgrammingPart1.GenericVehicle;

namespace Meeting3.AdvancedProgrammingPart1.ErrorWithException
{
    internal class Driver
    {
        public Driver(int id, ITransmission usedTransmission)
        {
            Id = id;
            UsedTransmission = usedTransmission;
        }

        public int Id { get; }
        
        public ITransmission UsedTransmission { get; }
    }
}