using System;
using Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._9.Pages;
using OpenQA.Selenium;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._9.DriverExtensions
{
    internal static class PageNavigator
    {
        public static TPage OpenPage<TPage>(this IWebDriver driver, Uri url) where TPage : Page
        {
            driver.Navigate().GoToUrl(url);
            return (TPage) Activator.CreateInstance(typeof(TPage), driver);
        }
    }
}