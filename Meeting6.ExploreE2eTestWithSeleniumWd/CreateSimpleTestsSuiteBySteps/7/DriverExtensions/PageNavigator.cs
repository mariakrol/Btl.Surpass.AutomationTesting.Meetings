using System;
using OpenQA.Selenium;

namespace Meeting6.ExploreE2eTestWithSeleniumWd.CreateSimpleTestsSuiteBySteps._7.DriverExtensions
{
    internal static class PageNavigator
    {
        public static TPage OpenPage<TPage>(this IWebDriver driver, Uri url) where TPage : class
        {
            driver.Navigate().GoToUrl(url);
            return (TPage) Activator.CreateInstance(typeof(TPage), driver);
        }
    }
}