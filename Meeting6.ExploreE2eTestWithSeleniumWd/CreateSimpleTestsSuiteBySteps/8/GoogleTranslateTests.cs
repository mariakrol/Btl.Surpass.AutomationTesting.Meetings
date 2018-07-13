using FluentAssertions;
using NUnit.Framework;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._8
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
            Translator.FillSourseText(sourcePhrase);
            Translator.Translate();
            var resultBoxText = Translator.GetTranslatedText();

            resultBoxText
                .Should()
                .Be(expectedPhrase);
        }
    }
}
