using Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes;
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
                .sh
        }
    }
}
