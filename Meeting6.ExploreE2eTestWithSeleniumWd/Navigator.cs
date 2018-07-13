using System;
using OpenQA.Selenium;

namespace Meeting6.ExploreE2eTestWithSeleniumWd
{
    internal static class Navigator
    {
        public static TPage OpenPage<TPage>(this IWebDriver driver, string url) where TPage : class 
        {
            driver.Navigate().GoToUrl(url);

            return (TPage) Activator.CreateInstance(typeof(TPage), driver);
        }
    }
}