using System;

namespace Meeting5.IntroductionToAutomatedTesting.LearnAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PageUrlAttribute : Attribute
    {
        public PageUrlAttribute(string url)
        {
            Url = url;
        }

        public string Url { get; }
    }
}