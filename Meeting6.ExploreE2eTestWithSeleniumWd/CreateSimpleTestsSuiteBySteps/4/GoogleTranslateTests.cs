using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._4
{
    [TestFixture]
    internal static class GoogleTranslateTests
    {
        private static IWebDriver Driver { get; set; }

        private static GoogleTranslator Translator { get; set; }

        [SetUp]
        public static void CreateDriver()
        {
            Driver = new ChromeDriver();
            Translator = new GoogleTranslator(Driver);
        }

        [Test]
        [TestCase("Привет!", "Hello!")]
        public static void TranslatePhraseIsExpected(string sourcePhrase, string expectedPhrase)
        {
            Translator.OpenGoogleTranslatePage();
            Translator.FillSourseTextFieldOnGoogleTranslatePage(sourcePhrase);
            Translator.ClickTranslateButtonOnGoogleTranslatePage();
            var resultBoxText = Translator.GetTranslatedTextFromGoogleTranslatePage();

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
