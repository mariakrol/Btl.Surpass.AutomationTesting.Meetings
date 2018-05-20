using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class E_OverrideEqualsAndGetHashCode
    {
        private static Employee Ben1500 => new Employee("Ben", 1500);
        private static Employee Ben2000 => new Employee("Ben", 2000);

        /// <summary>
        /// A hash code is a numeric value that is used to insert and
        /// identify an object in a hash-based collection.
        /// A hash code for two equal objects should always be the same.
        /// But there is an error in Employee type, Equals method use
        /// Name property of object to check equality, but GetHashCode method
        /// calculates a hash code based on Salary property.
        /// That's why we get inconsistent behavior here, two object which
        /// equals according to Equals method has a different hashes.
        /// </summary>
        [Test]
        public static void A_EqualsObjectHaveTheSameHash()
        {
            Trace.TraceInformation(
                "A hash it is a hash code of an object. If two objects are equals, then they always have the same hash.");

            bool isEmployeesEquals = Ben1500.Equals(Ben2000);

            (Ben1500.GetHashCode() == Ben2000.GetHashCode())
                .Should()
                .Be(isEmployeesEquals, "because equals objects should always have the same hash");
        }

        /// <summary>
        /// The HashSet class is based on the model of mathematical sets.
        /// A HashSet collection cannot contain equivalent elements.
        /// If two equivalent objects are added to the hashSet, the
        /// second one will be ignored.
        /// 
        /// HashSets are common data type and it is used often.
        /// That's why if you override methods in an incorrect way, third party
        /// libraries could works incorrect with your type if they use hashes under the hood.
        /// </summary>
        [Test]
        public static void B_HashSetStoreOnlyUniqItems()
        {
            Trace.TraceInformation("HashSet cannot contain several equals objects.");
            Trace.TraceInformation("If it is occur, only one object will get into the set.");
            var stringForSet1 = "string";
            var stringForSet2 = stringForSet1;
            var strigsSet = new HashSet<string> {stringForSet1, stringForSet2};

            strigsSet
                .Count
                .Should()
                .Be(1, "because two strings are equals and only one get into the set.");

            Trace.TraceInformation("If we create a HashSet with two objects of type Employee which is equals,");
            Trace.TraceInformation("the set should contain only one element.");
            Trace.TraceInformation(
                "But in our case Equals method will not be called at all (under the hood on adding of the element),");
            Trace.TraceInformation("because GetHashCode returns different values for objects and it clearly means,");
            Trace.TraceInformation("that objects are different, according to the specification of the language.");

            Trace.TraceInformation(
                "If you explore a result of test in the explorer, you will not find a debug print from the Equals method.");

            var employeesSet = new HashSet<Employee> {Ben1500, Ben2000};

            employeesSet
                .Count
                .Should()
                .Be(1, "because two objects are equals");
        }
    }
}