using FluentAssertions;
using Meeting3.AdvancedProgrammingPart1.GenericVehicle;
using NUnit.Framework;

namespace Meeting3.AdvancedProgrammingPart1
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class C_GenericClasses
    {
        [Test]
        public static void A_ConstructСlosedTypesBasedOnGenericWithOneParameter()
        {
            var vehicleWithAutomaticTransmission = new EquippedVehicle<AutomaticTransmission>(200);
            var vehicleWithManualTransmission = new EquippedVehicle<ManualTransmission>(240);

            vehicleWithManualTransmission.GetType()
                .BaseType
                .Should()
                .Be(vehicleWithAutomaticTransmission.GetType().BaseType);

        }

        [Test]
        public static void A_ConstructСlosedTypesBasedOnGenericWithSeveralParameters()
        {
            var vehicleWithAutomaticTransmission = new EquippedVehicle<AutomaticTransmission, GasEngine>(200);
            var vehicleWithManualTransmission = new EquippedVehicle<ManualTransmission, DieselEngine>(240);

            vehicleWithManualTransmission.GetType()
                .BaseType
                .Should()
                .Be(vehicleWithAutomaticTransmission.GetType().BaseType);

        }

        [Test]
        public static void A_ConstructСlosedTypesBasedOnDerivedGenericClass()
        {
            var sedanWithAutomaticTransmission = new Sedan<AutomaticTransmission>(200);
            var sedanWithManualTransmission = new Sedan<ManualTransmission>(240);

            sedanWithManualTransmission.GetType()
                .BaseType
                .Should()
                .Be(sedanWithAutomaticTransmission.GetType().BaseType);
        }
    }
}
