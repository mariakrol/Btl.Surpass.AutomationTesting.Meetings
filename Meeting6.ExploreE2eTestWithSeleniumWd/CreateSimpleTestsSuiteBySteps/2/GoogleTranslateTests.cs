using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._2
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
            
            Driver.Navigate().GoToUrl("https://translate.google.com");

            IWebElement sourceTextField = Driver.FindElement(By.CssSelector("#source"));
            sourceTextField.SendKeys(sourcePhrase);

            IWebElement translateButton = Driver.FindElement(By.CssSelector("#gt-submit"));
            translateButton.Click();

            IWebElement resultBox = Driver.FindElement(By.CssSelector("#result_box"));
            var resultBoxText = resultBox.Text;

            resultBoxText
                .Should()
                .Be(expectedPhrase);
        }

        [TearDown]
        public static void CloseDriver()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
