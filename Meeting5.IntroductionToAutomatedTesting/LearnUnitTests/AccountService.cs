namespace Meeting5.IntroductionToAutomatedTesting.LearnUnitTests
{
    public class AccountService
    {
        public AccountService(IBankWebService webService)
        {
            WebService = webService;
        }

        private IBankWebService WebService { get; }


        public string RegisterUser(string username, string creditCard)
        {
            AddUserToDatabase(username);

            bool success = WebService.Bill(creditCard);

            return success
                ? AccountServiceResources.CardAcceptedMessage
                : AccountServiceResources.CardDeclinedMessage;
        }

        // ReSharper disable once UnusedParameter.Local
        private void AddUserToDatabase(string username)
        {
            //Do nothing now
        }
    }
}