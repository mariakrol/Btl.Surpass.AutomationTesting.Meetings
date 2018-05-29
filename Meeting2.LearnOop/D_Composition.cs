using Meeting2.LearnOop.CompositionSamples;
using NUnit.Framework;

namespace Meeting2.LearnOop
{
    /// <summary>
    /// Objects can contain other objects in their instance variables;
    /// this is known as object composition.
    /// For example, an object of the Tractor class contain objects of the
    /// Wheel class and an object of nested class LoadingCrane,
    /// in addition to its own instance variables like "YearOfAssembly".
    /// Object composition is used to represent "has-a" relationships: every employee has an address,
    /// so every Tractor object has access to a place to store Wheels objects and a LoadingCrane object.
    /// </summary>
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class D_Composition
    {
        [Test]
        public static void A_ObjectCanUseItsComponentsWithoutInheritance()
        {
            var tractor = new Tractor(50, 2015, 4);

            tractor.Turn(isTurnRight: true);

            tractor.LoadСargo(3);
        }
    }
}
