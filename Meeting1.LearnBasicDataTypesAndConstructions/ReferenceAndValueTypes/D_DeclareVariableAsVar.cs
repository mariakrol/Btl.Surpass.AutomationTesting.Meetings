using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class D_DeclareVariableAsVar
    {
        [Test]
        public static void A_VariableDeclaredAsVarStillStronglyTyped()
        {
            Trace.TraceInformation("Variable, which is declared as var - is static typed variable");
            var integerVariable = 1;
            Trace.TraceInformation("Once introduced, it cannot change its type.");

            integerVariable.GetType()
                .Should()
                .Be(typeof(int));

            //If you uncomment code, listed below, you will got an error:
            //CS0029  Cannot implicitly convert type 'string' to 'int'
            //integerVariable = "I want to be a string";
        }

        [Test]
        public static void B_DeclareVariableWithAnonymousType()
        {
            Trace.TraceInformation("var could be used when the declared type has no specific name (anonymous)");

            string expectedName = "name of object";
            int expectedAge = 15;
            var anonymousType = new {Name = expectedName, Age = expectedAge};

            Trace.TraceInformation("You still has no specific name of type:");
            Trace.TraceInformation(anonymousType.GetType().ToString());

            Trace.TraceInformation(
                $"But you have an access to the fields. Name field: '{anonymousType.Name}', age field: '{anonymousType.Age}'");
            anonymousType.Name
                .Should()
                .Be(expectedName);

            anonymousType.Age
                .Should()
                .Be(expectedAge);
        }
    }
}