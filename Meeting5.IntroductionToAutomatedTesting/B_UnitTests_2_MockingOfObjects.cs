using Meeting5.IntroductionToAutomatedTesting.LearnUnitTests;
using NUnit.Framework;

namespace Meeting5.IntroductionToAutomatedTesting
{
    /// <summary>
    /// We can also use unit tests to simulate things outside of our control.
    /// Unit tests should run independent of any outside resources.
    /// Your tests shouldn't depend on a database being present, or a web service being available.
    /// So instead, we simulate these resources, so we can control what they return.
    /// In our app for example, We can't simulate a rejected credit card on registration.
    /// The bank probably would not like us submitting thousands of bad credit cards just to make sure our error handling code is correct.
    /// 
    /// The first thing, it would be very nice if we could check to see that if billing failed, the appropriate error message was returned.
    /// As it turns out, by using a mock, there's a way. Once you look at different mocking frameworks, there are even more powerful things you can do.
    /// You can verify your fake methods were called, you can verify the number of times a method was called, you can verify the parameters that methods were called with, etc.
    /// But now we use our manual-created 'mock' of real bank web service, called FakeBankWebService.
    /// 
    /// By using that fake object, anytime our bank's BillUser() is called, our fake object will always return false.
    /// Our unit test now verifies that if the call to the bank fails, RegisterUser() will return the correct error message.
    /// </summary>

    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public static class B_UnitTests_2_MockingOfObjects
    {
        private static AccountServices Services { get; set; }

        [SetUp]
        public static void CreateAccountService()
        {
            Services = new AccountServices(new FakeBankWebService());
        }

        [Test]
        [TestCase("asdasd")]
        [TestCase("378282246310005")]
        public static void UserIsNotRegisteredWithInvalidCard(string card)
        {
            var registrationResult = Services.RegisterUser("test_username", card);

            Assert.AreEqual(AccountServicesResources.CardDeclinedMessage, registrationResult);
        }

        [Test]
        [TestCase("asdasd")]
        [TestCase("378282246310005")]
        public static void UserIsRegisteredWithValidCard(string card)
        {
            var registrationResult = Services.RegisterUser("test_username", card);

            Assert.AreEqual(AccountServicesResources.CardAcceptedMessage, registrationResult);
        }
    }
}