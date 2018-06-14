using System.Collections.Generic;
using Meeting3.AdvancedProgrammingPart1.GenericVehicle;

namespace Meeting3.AdvancedProgrammingPart1.ErrorWithException
{
    internal class Garage
    {
        public Garage()
        {
            Staff = new DriversStaff();
        }

        public DriversStaff Staff { get; }

        // ReSharper disable once CollectionNeverQueried.Local
        private List<Driver> BusyDrivers { get; } = new List<Driver>();


        public void AssignDriverToVehicle(int driverId, ITransmission vehicleTransmission)
        {
            var driver = Staff.GetDriver(driverId);

            if (!vehicleTransmission.GetType().IsInstanceOfType(driver.UsedTransmission))
            {
                throw new DriverAssignException($"Selected driver cannot use transmission {vehicleTransmission}");
            }

            BusyDrivers.Add(driver);
        }
    }
}