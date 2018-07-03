using System;

namespace Meeting5.IntroductionToAutomatedTesting
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CssNameAttribute : Attribute
    {
        public CssNameAttribute(string nameAttribute)
        {
            NameAttribute = nameAttribute;
        }

        public string NameAttribute { get; }
    }
}