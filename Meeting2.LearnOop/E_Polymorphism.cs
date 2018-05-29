using System.Diagnostics;
using Meeting2.LearnOop.CompositionSamples;
using Meeting2.LearnOop.InheritanceSamples.Vehicles;
using Meeting2.LearnOop.PolymorphismSamples;
using NUnit.Framework;

namespace Meeting2.LearnOop
{
    /// <summary>
    /// 1) At run time, objects of a derived class may be treated
    /// as objects of a base class.
    /// When this occurs, the object's declared type is no longer identical
    /// to its run-time type.
    /// 
    /// 2) Base classes may define and implement virtual methods,
    /// and derived classes can override them, which means they provide
    /// their own definition and implementation. At run-time,
    /// when client code calls the method, the CLR looks up the run-time
    /// type of the object, and invokes that override of the virtual method.
    /// Thus in your source code you can call a method on a base class,
    /// and cause a derived class's version of the method to be executed.
    /// </summary>
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class E_Polymorphism
    {
        [Test]
        public static void A_ChildObjectsCanBeUsedAsBase()
        {
            Vehicle tractor = new Tractor(50, 2015, 4);
            Vehicle bicycle = new Bicycle(30);

            var washer = new CarWash();

            washer.Wash(tractor);
            washer.Wash(bicycle);
        }

        [Test]
        public static void B_ChildObjectCanOverrideBehavior()
        {
            Vehicle truck = new Truck(100);

            truck.IncreaseSpeed(15);
            truck.IndicateTurn(isRightTurn: false);

            Vehicle bicycle = new Bicycle(30);
            bicycle.IncreaseSpeed(5);
            bicycle.IndicateTurn(isRightTurn: false);
        }

        /// <summary>
        /// In case of using of member hiding we loose advantages
        /// of polymorphism, because when we use child object as base,
        /// a method from base class will be called.
        /// </summary>
        [Test]
        public static void B_ChildObjectCanHideBehavior()
        {
            Car car = new Car(100);

            car.ChangeColor("White");
            Trace.TraceInformation(car.ToString());

            ((Vehicle) car).ChangeColor("Green");
            Trace.TraceInformation(car
                .ToString()); // <- a method from base class will called instead of new one, which should hide source method

            // ReSharper disable once RedundantCast
            ((Vehicle) car)
                .IncreaseSpeed(
                    12); // <- a method from MotorVehicle class will called, because it override a source method
        }
    }
}