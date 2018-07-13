using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._5
{
    internal class GoogleTranslator
    {
        public GoogleTranslator()
        {
            Driver = new ChromeDriver();
        }

        private IWebDriver Driver { get; }

        public void OpenGoogleTranslatePage() => Driver.Navigate().GoToUrl("https://translate.google.com");

        public void FillSourseTextFieldOnGoogleTranslatePage(string sourcePhrase)
        {
            IWebElement sourceTextField = Driver.FindElement(By.CssSelector("#source"));
            sourceTextField.SendKeys(sourcePhrase);
        }

        public void ClickTranslateButtonOnGoogleTranslatePage()
        {
            IWebElement translateButton = Driver.FindElement(By.CssSelector("#gt-submit"));
            translateButton.Click();
        }

        public string GetTranslatedTextFromGoogleTranslatePage()
        {
            IWebElement resultBox = Driver.FindElement(By.CssSelector("#result_box"));
            return resultBox.Text;
        }

        ~GoogleTranslator()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}