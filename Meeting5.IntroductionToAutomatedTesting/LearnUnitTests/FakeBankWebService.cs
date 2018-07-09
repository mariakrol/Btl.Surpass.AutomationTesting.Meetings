namespace Meeting5.IntroductionToAutomatedTesting.LearnUnitTests
{
    public class FakeBankWebService : IBankWebService
    {
        public bool Bill(string creditCard)
        {
            return false; // our fake object always says billing failed
        }
    }
}