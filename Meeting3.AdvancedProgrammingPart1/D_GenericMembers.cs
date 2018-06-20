using FluentAssertions;
using Meeting3.AdvancedProgrammingPart1.GenericVehicle;
using NUnit.Framework;

namespace Meeting3.AdvancedProgrammingPart1
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class D_GenericMembers
    {
        [Test]
        public static void A_PropertyOfGenericClassParameter()
        {
            var expectedTransmission = new AutomaticTransmission();
            var sedanWithAutomaticTransmission = new Sedan<AutomaticTransmission>(200, expectedTransmission);

            sedanWithAutomaticTransmission.Transmission
                .Should()
                .Be(expectedTransmission);
        }

        [Test]
        public static void B_MethodWithGenericClassParameter()
        {
            var expectedTransmission = new AutomaticTransmission();
            var sedanWithAutomaticTransmission = new Sedan<AutomaticTransmission>(200);
            sedanWithAutomaticTransmission.ChangeTransmission(expectedTransmission);

            sedanWithAutomaticTransmission.Transmission
                .Should()
                .Be(expectedTransmission);
        }

        [Test]
        public static void C_MethodWithGenericParameter()
        {
            int left = 5;
            int leftCopy = left;

            int right = 10;
            int rightCopy = right;

            Swapper.Swap(ref left, ref right);

            left
                .Should()
                .Be(rightCopy);

            right
                .Should()
                .Be(leftCopy);
        }
    }
}