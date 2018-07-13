using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._1
{
    [TestFixture]
    internal static class GoogleTranslateTests
    {
        [Test]
        [TestCase("Привет!", "Hello!")]
        public static void TranslatePhraseIsExpected(string sourcePhrase, string expectedPhrase)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://translate.google.com");

            IWebElement sourceTextField = driver.FindElement(By.CssSelector("#source"));
            sourceTextField.SendKeys(sourcePhrase);

            IWebElement translateButton = driver.FindElement(By.CssSelector("#gt-submit"));
            translateButton.Click();

            IWebElement resultBox = driver.FindElement(By.CssSelector("#result_box"));
            var resultBoxText = resultBox.Text;

            resultBoxText
                .Should()
                .Be(expectedPhrase);

            driver.Quit();
            driver.Dispose();
        }
    }
}
