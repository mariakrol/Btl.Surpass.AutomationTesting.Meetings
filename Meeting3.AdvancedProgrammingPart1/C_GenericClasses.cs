using FluentAssertions;
using Meeting3.AdvancedProgrammingPart1.GenericVehicle;
using NUnit.Framework;

namespace Meeting3.AdvancedProgrammingPart1
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal class C_GenericClasses
    {
        [Test]
        public void A_ConstructСlosedTypesBasedOnGenericWithOneParameter()
        {
            var vehicleWithAutomaticTransmission = new EquippedVehicle<AutomaticTransmission>(200);
            var vehicleWithManualTransmission = new EquippedVehicle<AutomaticTransmission>(240);

            vehicleWithManualTransmission.GetType()
                .BaseType
                .Should()
                .Be(vehicleWithAutomaticTransmission.GetType().BaseType);

        }

        [Test]
        public void A_ConstructСlosedTypesBasedOnGenericWithSeveralParameters()
        {
            var vehicleWithAutomaticTransmission = new EquippedVehicle<AutomaticTransmission, GasEngine>(200);
            var vehicleWithManualTransmission = new EquippedVehicle<AutomaticTransmission, DieselEngine>(240);

            vehicleWithManualTransmission.GetType()
                .BaseType
                .Should()
                .Be(vehicleWithAutomaticTransmission.GetType().BaseType);

        }

        [Test]
        public void A_ConstructСlosedTypesBasedOnDerivedGenericClass()
        {
            var sedanWithAutomaticTransmission = new Sedan<AutomaticTransmission>(200);
            var sedanWithManualTransmission = new Sedan<AutomaticTransmission>(240);

            sedanWithManualTransmission.GetType()
                .BaseType
                .Should()
                .Be(sedanWithAutomaticTransmission.GetType().BaseType);
        }
    }
}
