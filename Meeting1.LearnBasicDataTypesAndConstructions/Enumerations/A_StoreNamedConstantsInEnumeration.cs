using System;
using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.Enumerations
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class A_StoreNamedConstantsInEnumeration
    {
        [Test]
        public static void A_ConvertEnumItemToBaseTypeAndBack()
        {
            var day = DayWithBaseInt.Sat;
            var intDay = (int) day;

            Trace.TraceInformation($"You can convert enum item to the number {day} => {intDay}.");

            var dayFromInt = (DayWithBaseInt) intDay;
            Trace.TraceInformation($"You can convert  it back: {intDay} => {dayFromInt}.");

            Trace.TraceInformation(
                $"You can use any number for transformation: (DayWithBaseInt) 7 => {(DayWithBaseInt) 5}.");

            Trace.TraceInformation("You even can use unexpected number:");

            Action convertIncorrectNumberToEum = () =>
            {
                int unexpectedNumberOfDay = 42;
                DayWithBaseInt unexpectedEnum = (DayWithBaseInt) unexpectedNumberOfDay;
                Trace.TraceInformation(
                    $"Wow, it is converted: {unexpectedEnum}, but has no name: '{Enum.GetName(typeof(DayWithBaseInt), unexpectedNumberOfDay)}'.");
            };

            convertIncorrectNumberToEum
                .Should()
                .NotThrow();
        }

        [Test]
        public static void B_UseAnyNumberTypeForEnum()
        {
            Trace.TraceInformation(
                "You can convert enum item to the number in case you use non-default number type too.");
            foreach (DayWithBaseByte day in Enum.GetValues(typeof(DayWithBaseByte)))
            {
                byte byteDay = (byte) day;

                Trace.TraceInformation($"{day} => {byteDay};");
            }
        }

        [Test]
        public static void C_UseNumbersWithoutOrderOrCalculate()
        {
            Trace.TraceInformation(
                "You can use any number, which will represent an enum item, you can even calculate it.");
            foreach (DayRandomNumber day in Enum.GetValues(typeof(DayRandomNumber)))
            {
                int intDay = (int) day;

                Trace.TraceInformation($"{day} => {intDay};");
            }
        }
    }
}