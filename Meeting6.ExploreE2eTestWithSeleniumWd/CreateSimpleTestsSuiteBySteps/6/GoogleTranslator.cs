using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._6
{
    internal class GoogleTranslator
    {
        public GoogleTranslator()
        {
            Driver = new ChromeDriver();
        }

        private IWebDriver Driver { get; }

        private GoogleTranslatePage GoogleTranslatePage { get; set; }

        public void OpenGoogleTranslatePage()
        {
            Driver.Navigate().GoToUrl("https://translate.google.com");
            GoogleTranslatePage = new GoogleTranslatePage(Driver);
        }

        public void FillSourseText(string sourcePhrase) => GoogleTranslatePage.SourceTextField.SendKeys(sourcePhrase);

        public void Translate() => GoogleTranslatePage.TranslateButton.Click();

        public string GetTranslatedText() => GoogleTranslatePage.ResultBox.Text;

        ~GoogleTranslator()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}