using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._3
{
    [TestFixture]
    internal static class GoogleTranslateTests
    {
        private static IWebDriver Driver { get; set; }

        [SetUp]
        public static void CreateDriver() => Driver = new ChromeDriver();

        [Test]
        [TestCase("Привет!", "Hello!")]
        public static void TranslatePhraseIsExpected(string sourcePhrase, string expectedPhrase)
        {
            OpenGoogleTranslatePage();
            FillSourseTextFieldOnGoogleTranslatePage(sourcePhrase);
            ClickTranslateButtonOnGoogleTranslatePage();
            var resultBoxText = GetTranslatedTextFromGoogleTranslatePage();

            resultBoxText
                .Should()
                .Be(expectedPhrase);
        }

        private static void OpenGoogleTranslatePage() => Driver.Navigate().GoToUrl("https://translate.google.com");

        private static void FillSourseTextFieldOnGoogleTranslatePage(string sourcePhrase)
        {
            IWebElement sourceTextField = Driver.FindElement(By.CssSelector("#source"));
            sourceTextField.SendKeys(sourcePhrase);
        }

        private static void ClickTranslateButtonOnGoogleTranslatePage()
        {
            IWebElement translateButton = Driver.FindElement(By.CssSelector("#gt-submit"));
            translateButton.Click();
        }

        private static string GetTranslatedTextFromGoogleTranslatePage()
        {
            IWebElement resultBox = Driver.FindElement(By.CssSelector("#result_box"));
            return resultBox.Text;
        }

        [TearDown]
        public static void CloseDriver()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
