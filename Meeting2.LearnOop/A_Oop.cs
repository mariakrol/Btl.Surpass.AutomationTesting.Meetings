using System.Diagnostics;
using FluentAssertions;
using Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes;
using Meeting2.LearnOop.ClassesWithConstructorsAndMethods;
using NUnit.Framework;

namespace Meeting2.LearnOop
{
    // internal access modifier on the class means, that access is limited to the current assembly.
    // That's why, if any third-party assembly import this, it would have no access to this class.

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
        /// 
        /// public access modifier on the method means, that all 
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

        /// <summary>
        /// Methods of instance level (not marked as static) are available for instances of a class.
        /// Methods can use data, which is passed by parameters, or they can use object itself (its fields and properties).
        /// </summary>
        [Test]
        public static void C_ObjectGotInstanceLevelMethodsFromClass()
        {
            var giftBox = new FilledColoredGiftBox("Novel", "White");

            // This method inly use value of passed argument - name.
            giftBox.PlaySong("Helen");

            // This method use data of the gift itself
            giftBox.PrintCongratulation();
        }

        /// <summary>
        /// Methods of class level (marked as static) are NOT available for instances of a class.
        /// They only could be called through class name.
        /// Such methods can use data, which is passed by parameters, or they can use class-level data (static fields or static properties).
        /// </summary>
        [Test]
        public static void D_ClassHasClassLevelMethods()
        {
            // Assume, our gifts could be delivered by single service
            Trace.TraceInformation($"Gifts delivery service: {FilledColoredGiftBox.GetDeliveryServiceName()}");

            FilledColoredGiftBox.ChangeDeliveryServiceName("Amazon");
            Trace.TraceInformation($"New gifts delivery service: {FilledColoredGiftBox.GetDeliveryServiceName()}");

            // if you uncomment following code, you get an error: 'CS0176  Member cannot be accessed with an instance reference; qualify it with a type name instead'
            // var gift = new FilledColoredGiftBox("Detective story", "Blue");
            // gift.GetDeliveryServiceName();
        }

        /// <summary>
        /// Extension methods enable you to "add" methods to existing types without creating a new derived type,
        /// recompiling, or otherwise modifying the original type.
        /// Extension methods are a special kind of static method, but they are called as if they were instance methods on the extended type.
        /// For client code written in C# there is no apparent difference between calling an extension method and the methods that are actually defined in a type.
        /// </summary>
        [Test]
        public static void E_ClassExtendedByThirdpartyMethod()
        {
            var trainee = new TraineeReferenceType("Berta", 43);

            trainee.ChangeAssesment(31);
        }
    }
}
