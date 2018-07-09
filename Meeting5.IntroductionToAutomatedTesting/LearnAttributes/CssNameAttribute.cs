using System;

namespace Meeting5.IntroductionToAutomatedTesting.LearnAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class CssNameAttribute : Attribute
    {
        public CssNameAttribute(string nameAttribute)
        {
            NameAttribute = nameAttribute;
        }

        public string NameAttribute { get; }
    }
}