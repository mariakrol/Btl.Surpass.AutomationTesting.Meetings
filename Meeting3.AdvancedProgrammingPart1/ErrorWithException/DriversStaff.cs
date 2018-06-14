using System;
using Meeting3.AdvancedProgrammingPart1.GenericVehicle;

namespace Meeting3.AdvancedProgrammingPart1.ErrorWithException
{
    internal class DriversStaff
    {
        public Driver GetDriver(int id)
        {
            foreach (var driver in _drivers)
            {
                if (driver.Id == id)
                {
                    return driver;
                }
            }

            throw new ArgumentException("Driver not found");
        }

        private readonly Driver[] _drivers = {
            new Driver(1, new ManualTransmission()),
            new Driver(2, new AutomaticTransmission()), 
        };
    }
}
