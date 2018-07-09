using FluentAssertions;
using Meeting5.IntroductionToAutomatedTesting.LearnUnitTests;
using NUnit.Framework;

namespace Meeting5.IntroductionToAutomatedTesting
{
    /// <summary>
    /// It's a common practice to treat unit testing as a way to test small individual pieces of code.
    /// The first place developers use unit tests is to verify some method works like he expect it to for all cases.
    /// Assume, we just recently wrote a validation method for a phone number for our "system".
    /// We accept only phone numbers, which are registered in USA.
    /// We want to make sure our validation method works for all the possible formats.
    /// Without a unit test, We'd be forced to manually enter each different format, and check that the form posts correctly.
    /// This is very tedious and error-prone. Later on, if someone makes a change to the phone validation code,
    /// it would be nice if we could easily check to make sure nothing else broke.
    /// 
    ///Each of our tests for the validator needs an Validator object, to check its method.
    ///It is possible to create a setup method, which can prepare all data before each test. We use method CreateValidator which is equipped with a SetUp attribute.
    ///When we start a new test run, NUnit find such method and run in before each test in the Fixture.
    ///
    ///Also, we should check not a single value, but a set of data, which are valid (or not) in our system, and we must to split steps of test and test date,
    ///each of our tests is equipped with TestCase attribute, which passes a test data to the test.
    /// </summary>

    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal class B_UnitTests_1_SimpleNunitAndFluentAssertions
    {
        private static UsPhoneNumberValidator Validator { get; set; }

        [SetUp]
        public static void CreateValidator()
        {
            Validator = new UsPhoneNumberValidator();
        }

        [Test]
        [TestCase("123-456-7890")]
        [TestCase("(123) 456-7890")]
        [TestCase("123 456 7890")]
        [TestCase("123.456.7890")]
        [TestCase("+1 (123) 456-7890")]
        public void UsPhoneNumberIsValid(string phone)
        {
            Validator.IsValid(phone)
                .Should()
                .BeTrue($"because {phone} is a valid phone number, registered in USA");
        }

        [Test]
        [TestCase("+2 (123) 456-7890")]
        [TestCase("+1 (123) 4563-789")]
        public void NonUsPhoneNumberIsNotValid(string phone)
        {
            Validator.IsValid(phone)
                .Should()
                .BeFalse("because only phone numbers, which are registered in USA are valid for the system");
        }

        [Test]
        [TestCase("123123123123123123123123123")]
        [TestCase("sdfsdfsdfsdf")]
        [TestCase("(123 - 123123")]
        public void NonPhonestringIsNotValid(string phone)
        {
            Validator.IsValid(phone)
                .Should()
                .BeFalse(
                    "because a valid format of phone is 1) + sign, 2) International Country Calling code, 3) Local Area code, 4) Local Phone number");
        }
    }
}