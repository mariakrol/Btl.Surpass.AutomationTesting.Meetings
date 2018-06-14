using System;
using FluentAssertions;
using Meeting3.AdvancedProgrammingPart1.ErrorWithException;
using Meeting3.AdvancedProgrammingPart1.GenericVehicle;
using NUnit.Framework;

namespace Meeting3.AdvancedProgrammingPart1
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class B_Exceptions
    {
        private const string StringFromTry = "In try";
        private const string StringFromCatch = "In catch";
        private const string StringFromFinally = "In finally";

        static B_Exceptions()
        {
            Garage = new Garage();
        }

        private static Garage Garage { get; }

        [Test]
        public static void A_CatchException()
        {
            Driver driver = null;

            try
            {
                driver = Garage.Staff.GetDriver(1000);
            }
            catch (ArgumentException)
            {
                Assert.Pass("Expected, that there is no driver with passed ID");
            }

            Assert.Fail($"Driver should not be found, but: {driver}");
        }

        [Test]
        public static void B_CodeAfterExceptionIsNotExecuted()
        {
            var debugVariable = "will be overwritten if no error";
            try
            {
                Garage.Staff.GetDriver(1000);
                debugVariable = StringFromTry;
            }
            catch (ArgumentException)
            {
                debugVariable
                    .Should()
                    .NotBe(StringFromTry);
            }
        }

        [Test]
        public static void C_FinallyCalledIfNoExceptionOccurs()
        {
            string debugVariable;
            
            try
            {
                Garage.Staff.GetDriver(3);
                // ReSharper disable once RedundantAssignment
                // this assignment is added just to show, that we overwrite it
                // by assignment in the finally block anyway.
                debugVariable = StringFromTry;
            }
            catch (ArgumentException)
            {
                // ReSharper disable once RedundantAssignment
                debugVariable = StringFromCatch;
            }
            finally
            {
                debugVariable = StringFromFinally;
            }

            debugVariable
                .Should()
                .Be(StringFromFinally);
        }

        [TestCase(ExpectedResult = StringFromFinally)]
        public static string D_FinallyCalledIfNoExceptionOccursAndValueReturned()
        {
            string debugVariable;

            try
            {
                Garage.Staff.GetDriver(3);
                debugVariable = StringFromTry;

                return debugVariable;
            }
            catch (ArgumentException)
            {
                // ReSharper disable once RedundantAssignment
                debugVariable = StringFromCatch;
            }
            finally
            {
                debugVariable = StringFromFinally;
            }

            return debugVariable;
        }

        [Test]
        public static void E_FinallyCalledIfExceptionOccurs()
        {
            string debugVariable;

            try
            {
                Garage.Staff.GetDriver(3000);
                // ReSharper disable once RedundantAssignment
                debugVariable = StringFromTry;
            }
            catch (ArgumentException)
            {
                // ReSharper disable once RedundantAssignment
                debugVariable = StringFromCatch;
            }
            finally
            {
                debugVariable = StringFromFinally;
            }

            debugVariable
                .Should()
                .Be(StringFromFinally);
        }

        [Test]
        public static void F_CustomExceptionCatch()
        {
            try
            {
                Garage.AssignDriverToVehicle(1, new AutomaticTransmission());
            }
            catch (DriverAssignException)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}