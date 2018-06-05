using System.Collections.Generic;
using Meeting3.AdvancedProgrammingPart1.VehicleParts;

namespace Meeting3.AdvancedProgrammingPart1
{
    internal class Garage
    {
        public Garage()
        {
            Staff = new DriversStaff();
        }

        public void AssignDriverToVehicle(int driverId, ITransmission vehicleTransmission)
        {
            var driver = Staff.GetDriver(driverId);

            if (!vehicleTransmission.GetType().IsInstanceOfType(driver.UsedTransmission))
            {
                //error?
            }

            BusyDrivers.Add(driver);

        }

        private List<Driver> BusyDrivers { get; } = new List<Driver>();

        private DriversStaff Staff { get; }
    }
}