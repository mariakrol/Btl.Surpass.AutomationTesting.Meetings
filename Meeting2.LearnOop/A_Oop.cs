using FluentAssertions;
using Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes;
using Meeting2.LearnOop.ClassesWithConstructors;
using NUnit.Framework;

namespace Meeting2.LearnOop
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class A_Oop
    {
        /// <summary>
        /// C# supports the notion of a class type, which is the cornerstone of OOP.
        /// A class may be composed of any number of members (such as constructors, properties, methods, and events)
        /// and data points (fields). It is something like "prototype" of an object.
        /// 
        /// An instance of a class - it is an object. Multiple objects can be created based on one class. 
        /// </summary>
        [Test]
        public static void A_CreateSeveralInstancesOfClass()
        {
            var traineeBerta = new TraineeReferenceType("Berta", 15);

            var traineeBob = new TraineeReferenceType("Bob", 23);

            traineeBerta
                .Should()
                .BeAssignableTo(traineeBob.GetType(), "because they both are objects of one type");
        }

        /// <summary>
        /// A constructor is a set of instructions, called on creation of an object.
        /// A constructor itself does not create an object.
        /// Under the hood, it is called after creation and it can initialize an object by setting up of its fields and properties.
        /// 
        /// If a constructor is not added to the class explicitly, the compiler generates a default constructor,
        /// it is not equipped with parameters and it initializes fields with its default values.
        /// 
        /// Constructors can be chained, it means, one constructor call another to initialize an object,
        /// if initialization logic is splitted.
        /// 
        /// When you will explore the sample, pay attention on results in a test runner,
        /// you will find a debug print from constructors.
        /// </summary>
        [Test]
        public static void B_CreateObject()
        {
            // Class with default constructor.
            var emptyGiftBox = new EmptyGiftBox();

            emptyGiftBox
                .Should()
                .NotBeNull();
            
            // Class with parametrized constructor
            var poem = "poem";

            var filledGiftBox = new FilledGiftBox(poem);
            filledGiftBox
                .Should()
                .NotBeNull();

            filledGiftBox
                .Gift
                .Should()
                .Be(poem);

            // Class with chained constructors
            var tale = "Tale";
            var boxColor = "Yellow";
            var filledColoredGiftBox = new FilledColoredGiftBox(tale, boxColor);
            filledColoredGiftBox
                .Should()
                .NotBeNull();

            filledColoredGiftBox
                .Gift
                .Should()
                .Be(tale);

            filledColoredGiftBox
                .Color
                .Should()
                .Be(boxColor);
        }
    }
}
