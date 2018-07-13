using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._9.Pages
{
    internal abstract class Page
    {
        protected Page(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        private IWebDriver Driver { get; }
    }
}