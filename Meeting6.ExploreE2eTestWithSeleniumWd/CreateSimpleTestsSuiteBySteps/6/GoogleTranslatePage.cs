using OpenQA.Selenium;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._6
{
    internal class GoogleTranslatePage
    {
        public GoogleTranslatePage(IWebDriver driver)
        {
            Driver = driver;
        }
        private IWebDriver Driver { get; }

        public IWebElement SourceTextField => Driver.FindElement(By.CssSelector("#source"));

        public IWebElement TranslateButton => Driver.FindElement(By.CssSelector("#gt-submit"));

        public IWebElement ResultBox => Driver.FindElement(By.CssSelector("#result_box"));
    }
}