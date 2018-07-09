using System.Text.RegularExpressions;

namespace Meeting5.IntroductionToAutomatedTesting.LearnUnitTests
{
    public class UsPhoneNumberValidator
    {
        public bool IsValid(string phone)
        {
            var usPhoneMatcher = new Regex("^(\\+0?1\\s)?\\(?\\d{3}\\)?[\\s.-]\\d{3}[\\s.-]\\d{4}$");

            return usPhoneMatcher.IsMatch(phone);
        }
    }
}