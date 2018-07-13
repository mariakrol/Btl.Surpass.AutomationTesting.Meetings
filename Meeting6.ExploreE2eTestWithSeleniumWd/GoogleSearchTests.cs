using FluentAssertions;
using NUnit.Framework;

namespace Meeting6.ExploreE2eTestWithSeleniumWd
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class GoogleSearchTests
    {
        private static GoogleSearch GoogleSearch { get; set; }

        [SetUp]
        public static void InitDriver()
        {
            GoogleSearch = new GoogleSearch();
        }

        [Test]
        [TestCase("Foo")]
        public static void TextIsFound(string searchText) {

            var page = GoogleSearch.OpenGoogleSearchPage();

            GoogleSearch.SerchTextOnPage(page, searchText);

            GoogleSearch.GetPageSource()
                .Should()
                .Contain(searchText);
        }
    }
}
