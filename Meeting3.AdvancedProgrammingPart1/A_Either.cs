using FluentAssertions;
using Meeting3.AdvancedProgrammingPart1.ValidationWithEither;
using NUnit.Framework;

namespace Meeting3.AdvancedProgrammingPart1
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class A_Either
    {
        static A_Either()
        {
            PageWithField = new PageWithFieldModel();
        }

        private static PageWithFieldModel PageWithField { get; }

        [Test]
        public static void A_GetErrorFromEither()
        {
            var fieldValueOrError = PageWithField.FillField(100);

            fieldValueOrError.Left
                .Should()
                .NotBeNullOrEmpty("because an error expected");

            fieldValueOrError.Right
                .Should()
                .Be(default(int), "because is a error filled, value cannot be filled");
        }

        [Test]
        public static void B_GetValueFromEither()
        {
            var expectedValue = 17;
            var fieldValueOrError = PageWithField.FillField(expectedValue);

            fieldValueOrError.Left
                .Should()
                .BeNullOrEmpty("because successful fill is expected");

            fieldValueOrError.Right
                .Should()
                .Be(expectedValue, "because value expected to be valid");
        }
    }
}
