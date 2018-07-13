using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageNavigator = Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._8.DriverExtensions.PageNavigator;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._7
{
    internal class GoogleTranslator
    {
        public GoogleTranslator()
        {
            Driver = new ChromeDriver();
        }

        private IWebDriver Driver { get; }

        private GoogleTranslatePage GoogleTranslatePage { get; set; }

        public void OpenGoogleTranslatePage() => GoogleTranslatePage = PageNavigator.OpenPage<GoogleTranslatePage>(Driver, GoogleTranslatePage.Url);

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