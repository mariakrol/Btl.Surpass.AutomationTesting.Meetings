using System;

namespace Meeting5.IntroductionToAutomatedTesting
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CheckControlAttribute : Attribute
    {
        public CheckControlAttribute(string controlMemberName)
        {
            ControlMemberName = controlMemberName;
        }

        public string ControlMemberName { get; }
    }
}