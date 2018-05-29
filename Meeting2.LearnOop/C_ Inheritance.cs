using System.Diagnostics;
using FluentAssertions;
using Meeting2.LearnOop.InheritanceSamples.MultyInheritedVehicles;
using Meeting2.LearnOop.InheritanceSamples.Vehicles;
using NUnit.Framework;

namespace Meeting2.LearnOop
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class C_Inheritance
    {
        /// <summary>
        /// Inheritance allows classes to be arranged in a hierarchy that represents "is-a-type-of" relationships.
        /// For example, class Bicycle might inherit from class Vehicle.
        /// All the data and methods available to the parent class also appear in the child class with the same names.
        /// This technique allows easy re-use of the same procedures and data definitions,
        /// in addition to potentially mirroring real-world relationships in an intuitive way.
        /// </summary>
        [Test]
        public static void A_ChildClassGotMembersFromParent()
        {
            // ChangeColor method is introduced in the base class,
            //but each child can use it
            var car = new Car(200);
            car.ChangeColor("Green");

            var bicycle = new Bicycle(25);
            bicycle.ChangeColor("Red");
        }

        /// <summary>
        /// If a class is inherited from other class and in addition 
        /// it inherited from several interfaces, each got a behavior from
        /// the base class and from each interface.
        /// </summary>
        [Test]
        public static void B_ClassWhichIsIheritedFromSeveralEntitysGotEachBehavior()
        {
            var companyVehicle = new CompanyVehicle(100)
            {
                Color = "Black",
                SumInsured = 1000000,
                Cost = 250000

            };

            Trace.TraceInformation($"Get value of property from the base class: {companyVehicle.Color}");

            Trace.TraceInformation($"Get value of property from IAsset interface: {companyVehicle.Cost}");

            Trace.TraceInformation($"Get value of property from IInshured interface: {companyVehicle.SumInsured}");
        }

        [Test]
        public static void C_SealedClassInstantiatable()
        {
            var bicycle = new Bicycle(30);

            bicycle
                .Should()
                .NotBeNull();
        }

        [Test]
        public static void C_SealedClassExtandable()
        {
            var bicycle = new Bicycle(30);

            bicycle.UpBicycleSeat();
        }
    }
}
