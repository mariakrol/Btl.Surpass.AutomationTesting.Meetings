using Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._8.DriverExtensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._8
{
    internal class GoogleTranslator
    {
        public GoogleTranslator()
        {
            Driver = new ChromeDriver();
        }

        private IWebDriver Driver { get; }

        private GoogleTranslatePage GoogleTranslatePage { get; set; }

        public void OpenGoogleTranslatePage() => GoogleTranslatePage = Driver.OpenPage<GoogleTranslatePage>(GoogleTranslatePage.Url);

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