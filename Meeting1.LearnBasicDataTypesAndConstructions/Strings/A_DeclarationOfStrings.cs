using System;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.Strings
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class A_DeclarationOfStrings
    {
        [Test]
        public static void A_DeclareWithoutInitializing()
        {
            Trace.TraceInformation(
                "A string could be declared but not initialized. And it does not cause an error (string declaredButNotInitialized;).");

            // ⬇️ C# preprocessor directive, it allows ignoring warning 219 of the compiler.
            // This warning occurs because variable declareAndInitializeToNull is assigned,
            // but its value is never used.
            // Here, as for ReSharper warnings, it is a bad way to ignore it,
            // but in this case, we had to declare the variable without usage to show,
            // that it is possible.
#pragma warning disable 168

            Action declareStringWithoutInitialization = () =>
            {
                string declaredButNotInitialized;
            };

#pragma warning restore 168

            declareStringWithoutInitialization
                .Should()
                .NotThrow();

            Trace.TraceInformation(
                "But you should initialize such string before getting it. String without initialization is not null string - it is nothing at all.");
            Trace.TraceInformation(
                "That's why if you will try to get it, you will get a compile time error 'CS0165  Use of unassigned local variable':" +
                "\n\tstring declaredButNotInitialized;\n\tTrace.TraceInformation(declaredButNotInitialized1); -> CS0165  Use of unassigned local variable");

            //if you uncomment lines below, you will get a compile-time error: CS0165  Use of unassigned local variable
            //string declaredAndUsed;
            //Trace.TraceInformation(declaredAndUsed);
        }

        [Test]
        public static void B_DeclareAndInitializeToNull()
        {
            Trace.TraceInformation(
                "A string could be declared and initialized as null. And it does not cause an error (string declareAndInitializeToNull = null;).");

#pragma warning disable 219

            Action declareStringAndInitializeAsNull = () =>
            {
                string declareAndInitializeToNull = null;
            };

#pragma warning restore 219

            declareStringAndInitializeAsNull
                .Should()
                .NotThrow();

            Trace.TraceInformation(
                "Furthermore, you can use such string:\n\tstring declareAndInitializeToNull = null;\n\tTrace.TraceInformation(declareAndInitializeToNull);");

            Action declareStringInitializeAsNullAndUse = () =>
            {
                string declareAndInitializeToNull = null;
                // ReSharper disable once ExpressionIsAlwaysNull
                Trace.TraceInformation(
                    $"A null string is usable, it is printed between quotes here: '{declareAndInitializeToNull}'");
            };
            declareStringInitializeAsNullAndUse
                .Should()
                .NotThrow();
        }

        [Test]
        public static void C_DeclareAndInitializeToEmpty()
        {
            Trace.TraceInformation(
                "A string could be declared and initialized as empty. And it does not cause an error (string declareAndInitializeToEmpty = string.Empty;).");

            // ReSharper disable once UnusedVariable
            Action declareStringAndInitializeAsEmpty = () =>
            {
                string declareAndInitializeToEmpty = string.Empty;
            };
            declareStringAndInitializeAsEmpty
                .Should()
                .NotThrow();

            Trace.TraceInformation(
                "You can use such string:\n\tstring declareAndInitializeToNull = null;\n\tTrace.TraceInformation(declareAndInitializeToNull);");

            Action declareStringInitializeAsEmptyAndUse = () =>
            {
                string declareAndInitializeToEmpty = string.Empty;
                Trace.TraceInformation(
                    $"An empty string is usable, it is printed between quotes here: '{declareAndInitializeToEmpty}'");
            };
            declareStringInitializeAsEmptyAndUse
                .Should()
                .NotThrow();
        }

        [Test]
        public static void D_DeclareWithoutTypeKeyword()
        {
            Trace.TraceInformation(
                "A string could be declared without type keyword. (String declareWithoutTypeKeyword;).");

            Action declareStringWithoutTypeKeywordAndUse = () =>
            {
                String declareWithoutTypeKeyword = "declared as System.String";
                Trace.TraceInformation($"String is declared without type keyword: '{declareWithoutTypeKeyword}'");
            };
            declareStringWithoutTypeKeywordAndUse
                .Should()
                .NotThrow();
        }

        [Test]
        public static void E_DeclareAsConstant()
        {
            Trace.TraceInformation(
                "A string could be declared as constant. (const string constantString = \"You can't get rid of me!\";).");

            Action declareConstantStringAndUse = () =>
            {
                const string constantString = "You can't get rid of me!";
                Trace.TraceInformation($"String is declared as constant: '{constantString}'");
            };
            declareConstantStringAndUse
                .Should()
                .NotThrow();

            Trace.TraceInformation("You cannot change such string after declaring.");
            Trace.TraceInformation(
                "That's why if you will try to edit it, you will get a compile time error 'CS0131  The left-hand side of an assignment must be a variable, property or indexer':" +
                "\n\tconst string constantString = \"You can't get rid of me!\";\n\tconstantString = \"But I want!!\"; -> CS0131  The left-hand side of an assignment must be a variable, property or indexer");

            //if you uncomment lines below, you will get a compile-time error: CS0131  The left-hand side of an assignment must be a variable, property or indexer
            //string declaredAndUsed;
            //Trace.TraceInformation(declaredAndUsed);
        }

        [Test]
        public static void F_InitializaAsCharsArray()
        {
            Trace.TraceInformation(
                "A string could be initialized as an array of chars. (string alphabet = new string(new[] { 'A', 'B', 'C' });).");

            var charsOfAlphabet = new[] {'A', 'B', 'C'};
            string alphabet = new string(charsOfAlphabet);

            Trace.TraceInformation("Each char, which was passed to the constructor appears in the result string.");
            alphabet
                .Should()
                .ContainAll(charsOfAlphabet.Select(@char => @char.ToString()));

            Trace.TraceInformation(
                "Chars will be merged one by one without separators. It means, that if you use new[] { 'A', 'B', 'C' }, you get \"ABC\" string");
            alphabet
                .Should()
                .Be("ABC");
        }

        [Test]
        public static void G_DeclareAndInitializeWithDifferentStringLiterals()
        {
            Trace.TraceInformation("Regular string literal it is a characters enclosed in double quotes.");
            Trace.TraceInformation("It may include both simple escape sequences (such as \\t for the tab character)" +
                                   " and hexadecimal and Unicode escape sequences");

            Trace.TraceInformation(
                "If you will initialize string, which should contain backslashes, with regular string literal, you should escape it with second backslash:");
            Trace.TraceInformation(
                "\tstring stringWithRegularLiteral = \"c:\\\\Program Files\\\\Microsoft Visual Studio 8.0\";");

            string stringWithRegularLiteral = "c:\\Program Files\\Microsoft Visual Studio 8.0";

            Trace.TraceInformation(
                "If you will initialize string, which should contain backslashes, with verbatim string literal, you should not escape it, but '@' sign is required in this case:");
            Trace.TraceInformation(
                "\tstring stringWithRegularLiteral = @\"c:\\Program Files\\Microsoft Visual Studio 8.0\";");

            string stringWithVerbatimLiteral = @"c:\Program Files\Microsoft Visual Studio 8.0";

            Trace.TraceInformation(
                $"Your strings exactly the same. Regular string literal = '{stringWithRegularLiteral}', verbatim string = '{stringWithVerbatimLiteral}'.");

            stringWithRegularLiteral
                .Should()
                .Be(stringWithVerbatimLiteral);
        }
    }
}