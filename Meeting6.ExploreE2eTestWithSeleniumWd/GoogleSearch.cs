using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Meeting6.ExploreE2eTestWithSeleniumWd
{
    internal class GoogleSearch
    {
        public GoogleSearch()
        {
            Driver = new ChromeDriver();
        }
        
        private IWebDriver Driver { get; }

        public GoogleSearchPage OpenGoogleSearchPage() => Driver.OpenPage<GoogleSearchPage>("https://www.google.ru");

        public void SerchTextOnPage(GoogleSearchPage page, string searchText) => page.SearchField.SendKeys(searchText + Keys.Enter);

        public string GetPageSource() => Driver.PageSource;

        ~GoogleSearch()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
