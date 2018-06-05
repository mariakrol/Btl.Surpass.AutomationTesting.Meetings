using Meeting3.AdvancedProgrammingPart1.VehicleParts;

namespace Meeting3.AdvancedProgrammingPart1
{
    internal class Driver
    {
        public Driver(int id, ITransmission usedTransmission)
        {
            Id = id;
            UsedTransmission = usedTransmission;
        }

        public int Id { get; set; }
        
        public ITransmission UsedTransmission { get; set; }
    }
}