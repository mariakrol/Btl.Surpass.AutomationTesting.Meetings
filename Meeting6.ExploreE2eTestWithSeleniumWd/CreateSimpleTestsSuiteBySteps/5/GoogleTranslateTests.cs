using FluentAssertions;
using NUnit.Framework;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._5
{
    [TestFixture]
    internal static class GoogleTranslateTests
    {
        private static GoogleTranslator Translator { get; set; }

        [SetUp]
        public static void CreateDriver()
        {
            Translator = new GoogleTranslator();
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
    }
}
