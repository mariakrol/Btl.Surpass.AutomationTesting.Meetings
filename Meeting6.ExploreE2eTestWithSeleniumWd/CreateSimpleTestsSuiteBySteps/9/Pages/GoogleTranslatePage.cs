using System;
using JetBrains.Annotations;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._9.Pages
{
    [UsedImplicitly]
    internal class GoogleTranslatePage : Page
    {
        public static readonly Uri Url = new Uri("https://translate.google.com");

        public GoogleTranslatePage(IWebDriver driver) : base (driver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "#source")]
        public IWebElement SourceTextField;

        [FindsBy(How = How.CssSelector, Using = "#gt-submit")]
        public IWebElement TranslateButton;

        [FindsBy(How = How.CssSelector, Using = "#result_box")]
        public IWebElement ResultBox;
    }
}