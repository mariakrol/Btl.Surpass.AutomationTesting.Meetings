using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Meeting5.IntroductionToAutomatedTesting.LearnAttributes;
using NUnit.Framework;

namespace Meeting5.IntroductionToAutomatedTesting
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class A_Attributes
    {
        [Test]
        public static void A_GetAttributeOnType()
        {
            IEnumerable<PageUrlAttribute> pageUrlAttribute = typeof(GooglePage).GetCustomAttributes<PageUrlAttribute>();

            pageUrlAttribute
                .Should()
                .HaveCount(1);
        }

        [Test]
        public static void B_GetAttributeOnObject()
        {
            var googlePage = new GooglePage();

            IEnumerable<PageUrlAttribute> pageUrlAttribute = googlePage.GetType().GetCustomAttributes<PageUrlAttribute>();

            pageUrlAttribute
                .Should()
                .HaveCount(1);
        }

        [Test]
        public static void C_GetAttributeFromMember()
        {
            var googlePageType = typeof(GooglePage);
            PropertyInfo property = googlePageType.GetProperty(nameof(GooglePage.SearchField), BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance);
            FieldInfo field = googlePageType.GetField(nameof(GooglePage.SearchButton));
            MethodInfo method = googlePageType.GetMethod(nameof(GooglePage.IsPageLoaded));

            var nameAttributesOnProperty = property?.GetCustomAttributes<CssNameAttribute>();
            var nameAttributesOnField = field.GetCustomAttributes<CssNameAttribute>();
            var checkControlAttributesOnMethod = method?.GetCustomAttributes<CheckControlAttribute>();

            nameAttributesOnProperty.Should()
                .HaveCount(1);

            nameAttributesOnField.Should()
                .HaveCount(1);

            checkControlAttributesOnMethod.Should()
                .NotBeEmpty();
        }
    }
}
