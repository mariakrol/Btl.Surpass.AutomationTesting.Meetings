using System;
using JetBrains.Annotations;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._8
{
    [UsedImplicitly]
    internal class GoogleTranslatePage
    {
        public static readonly Uri Url = new Uri("https://translate.google.com");

        public GoogleTranslatePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }
        private IWebDriver Driver { get; }

        [FindsBy(How = How.CssSelector, Using = "#source")]
        public IWebElement SourceTextField;

        [FindsBy(How = How.CssSelector, Using = "#gt-submit")]
        public IWebElement TranslateButton;

        [FindsBy(How = How.CssSelector, Using = "#result_box")]
        public IWebElement ResultBox;
    }
}