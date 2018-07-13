using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Meeting6.ExploreE2eTestWithSeleniumWd
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class GoogleSearchPage
    {
        public GoogleSearchPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this, new DefaultPageObjectMemberDecorator());
        }

        private IWebDriver Driver { get; }

        [FindsBy(How = How.CssSelector, Using = "#lst-ib")]
        public IWebElement SearchField { get; set; }
    }
}