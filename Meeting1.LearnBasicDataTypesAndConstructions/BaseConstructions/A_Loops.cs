using System.Diagnostics;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.BaseConstructions
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class A_Loops
    {
        [Test]
        public static void A_ForLoop()
        {
            Trace.TraceInformation("Loop 'for' can be used to repeat operation for a several times:");

            for (int i = 0; i < 5; i++)
            {
                Trace.TraceInformation($"\tNumber of cycle: {i}");
            }

            Trace.TraceInformation("Or it can be used to interact with items in a collection:");
            string[] strings = {"one", "two", "three"};
            for (int i = 0; i < strings.Length; i++)
            {
                // In this case it is not so idiomatic to use for loop here
                // because we only get an access to the item by its index.
                // We shows, that it is possible but in the real world
                // foreach loop is more suitable for simple walk between items, as here.
                Trace.TraceInformation($"\tItem of array at {i} index is {strings[i]}");
            }

            Trace.TraceInformation("You can go forward, as before, or you can use reversed order:");
            for (int i = strings.Length - 1; i >= 0; i--)
            {
                Trace.TraceInformation($"\tItem of array at {i} index is {strings[i]}");
            }
        }

        [Test]
        public static void B_ForeachLoop()
        {
            Trace.TraceInformation(
                "'Foreach' loop can be used to interact with items in a collection. You had use no indexes at this case:");
            string[] numbers = {"one", "two", "three"};
            foreach (var number in numbers)
            {
                Trace.TraceInformation(number);
            }
        }

        [Test]
        public static void C_WhileAndDoWhileLoops()
        {
            Trace.TraceInformation(
                "Do/While loop is differs from While loop, because Do/While ever perform its first cycle.");
            string[] numbers = {"one", "two", "three"};
            int index = 0;

            do
            {
                Trace.TraceInformation("\tIn the Do/While loop!");
                break;

                //Compiler is a smart guy, it finds, that condition in While statement
                //will never be executed, that's why it tells us, that it is redundant block.
#pragma warning disable 162
            } while (numbers[index] != "one");

#pragma warning restore 162

            Trace.TraceInformation(
                "While loop checks its condition before the first cycle, that's why he can never get into a body.");
            while (numbers[index] != "one")
            {
                Trace.TraceInformation("\tIn the While loop!");
                break;
            }
        }
    }
}