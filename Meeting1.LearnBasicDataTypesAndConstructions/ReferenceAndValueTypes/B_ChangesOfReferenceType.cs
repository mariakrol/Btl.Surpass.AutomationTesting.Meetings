using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class B_ChangesOfReferenceType
    {
        /// <summary>
        /// When we operate on reference type and pass it to a method,
        /// essentially, we pass a reference to the area of memory,
        /// where an object is placed.
        /// A called method gets a reference to the source object, not a copy.
        /// That's why the called method and the caller use the same object,
        /// and, of course, each change which is performed in the called method,
        /// become available in the caller.
        /// 
        /// Here we create a variable of TraineeReferenceType type and pass it to the method,
        /// which increments a value of assessment and return the whole trainee back to the caller.
        /// We can see, that the called method return the same value, which is placed
        /// in the caller in sourceTrainee variable, but sourceTrainee variable contains a value,
        /// which is not matches with expectedTrainee variable
        /// because sourceTrainee changed in the called method.
        /// </summary>
        [Test]
        public static void A_ChangeOfFieldWithValueTypeForComplexReferenceTypePassedByReferenceIsTakeEffectInCaller()
        {
            var sourceTrainee = new TraineeReferenceType("Kate", 2);
            var expectedTrainee = new TraineeReferenceType("Kate", 2);
            Trace.TraceInformation(
                $"Create a variable of a complex reference type. Type: TraineeReferenceType, value = '{sourceTrainee}'.");

            Trace.TraceInformation("Pass it to the method, which increment property 'Assessment' (value type - int).");
            var changedTrainer = TypesChanger.IncrementAssessmentOfTrainee(sourceTrainee);

            Trace.TraceInformation("Expected, that the value in the caller is incremented in the same way " +
                                   "as the value in the method, which was called." +
                                   "It occurs because an object of a reference type is passed by reference and " +
                                   "the called method did operate on the same object, which is declared in the caller.");

            Trace.TraceInformation(
                $"Compare the source assessment with expected (Assessment of a source trainee should be greater): source = '{sourceTrainee.Assessment}'; expected = '{expectedTrainee.Assessment}'.");
            sourceTrainee.Assessment
                .Should()
                .BeGreaterThan(expectedTrainee.Assessment);

            Trace.TraceInformation(
                "Compare changed assessment with the original (The changed value should be the same): " +
                $"changed = '{changedTrainer.Assessment}'; original = '{sourceTrainee.Assessment}'.");
            changedTrainer.Assessment
                .Should()
                .Be(sourceTrainee.Assessment);
        }

        /// <summary>
        /// A string type is a reference type. But it works in a different way.
        /// Each time you change a string, а new object is created in the memory.
        /// A source object stay at the memory (for a several time),
        /// but our variable is not referenced on it any more.
        /// When you pass a variable of string type to a method, you pass it by reference,
        /// but a reference on it is passed by value.
        /// When you change an object, you create a new reference,
        /// but you cannot pass it to the caller, because the source reference
        /// is passed by value, it is simply a copy of a source reference.
        /// </summary>
        [Test]
        public static void B_ChangeOfStringPassedByReferenceIsNotTakeEffectInCaller()
        {
            var sourceString = "I am a source string ";
            var expectedString = sourceString;
            Trace.TraceInformation($"Create a string variable. Type: string, value = '{sourceString}'.");

            Trace.TraceInformation("Pass it to the method, which concatenate it with GUID.");
            var changedString = TypesChanger.ConcatenateStringWithGuid(sourceString);

            Trace.TraceInformation("Expected, that the value in the caller is not affected, " +
                                   "because a new copy of string will always be created.");

            Trace.TraceInformation("Compare the source string with expected (Should be the same): " +
                                   $"source = '{sourceString}'; expected = '{expectedString}'.");

            sourceString
                .Should()
                .Be(expectedString, "because a new copy of the string is created always");

            Trace.TraceInformation("The changed value should start with the original string: " +
                                   $"original = '{sourceString}'; changed = '{changedString}'.");
            changedString
                .Should()
                .StartWith(expectedString);
        }

        /// <summary>
        /// Variables of reference type are passed by reference to a method.
        /// It means, that the source variable and object, which is passed
        /// to the method are references to the same area in the memory.
        /// But the reference on the object is passed by value, changes of
        /// reference in the called method is not made an effect in the caller.
        /// When we interact with an array, we pass it to the method by reference,
        /// that's why the called method has an access to items of an array by reference,
        /// and, when it changes some item, it makes an effect on the initial array.
        /// But when the parameter  that referred to the source object is assigned
        /// with a completely new object  in the called method, the object in this
        /// method starts referring to a new reference, but the caller knows nothing
        /// about it, because it passed a copy of a reference on its object,
        /// and its object is not affected.
        /// </summary>
        [Test]
        public static void C_ChangeItemInArrayOfItemsWithValueType()
        {
            var sourceArray = new[] {1, 2, 3};
            int[] expectedArray = new int[sourceArray.Length];
            Array.Copy(sourceArray, expectedArray, sourceArray.Length);

            Trace.TraceInformation("Create an array of items with value type. " +
                                   $"Type: int[], value = '{Utilities.CreateString(sourceArray)}'.");

            Trace.TraceInformation("Pass it to the method, which increments the " +
                                   "first item by index, then it override whole array.");
            var changedArray = TypesChanger.IncrementFirstItemByIndexThenOverrideArray(sourceArray);

            Trace.TraceInformation("Expected, that only the first item is changed, not the whole array, " +
                                   "because array is passed by reference, BUT reference is passed by value. " +
                                   "When we override the whole array, we create a new reference, which can not be passed back to the caller.");

            Trace.TraceInformation(
                "Compare the source array with expected (Should not be the same, because first item is incremented): " +
                $"source = '{Utilities.CreateString(sourceArray)}'; expected = '{Utilities.CreateString(expectedArray)}'.");

            sourceArray
                .Should()
                .StartWith(++expectedArray[0])
                .And
                .EndWith(expectedArray.Skip(1).ToArray());

            Trace.TraceInformation(
                "A new array, which is created in the called method is not match to original array: " +
                $"original = '{Utilities.CreateString(sourceArray)}'; changed = '{Utilities.CreateString(changedArray)}'.");
            changedArray
                .Should()
                .NotContain(expectedArray);
        }

        /// <summary>
        /// In case we use an array and interact with its item, 
        /// we get this item by reference from indexer of an array
        /// (getter of indexer in an array return an item by reference).
        /// This means, that item of an array with target index and 
        /// object, that we get by index will referring to the same
        /// object in the memory and when we change item, which was got
        /// by index, we change a source object in the memory.
        /// 
        /// In the other case, when we use a list, a behavior will not
        /// be the same. Indexer of a list return us a new copy
        /// of an object (from getter of indexer), which is placed
        /// at the target index.
        /// It means, that if we want to change some property of an item
        /// in the list, we should store a copy in a variable, change properties
        /// and then put it back (override an item by index) to the list
        /// (setter of an indexer override an item by reference).
        /// </summary>
        [Test]
        public static void D_DiscoverDiferenceBetweenIndexersOfArrayAndList()
        {
            var sourceArrayOfValueType = new[] {new TrainerValueType("Peat", 1), new TrainerValueType("Kelly", 3)};
            var expectedArrayOfValueType = new[] {new TrainerValueType("Peat", 1), new TrainerValueType("Kelly", 3)};
            Trace.TraceInformation("Create an array of items with value type TrainerValueType. " +
                                   $"Type: TrainerValueType[], value = '{Utilities.CreateString(sourceArrayOfValueType)}'.");

            Trace.TraceInformation("Pass it to the method, which increments a property of the first item by index");
            TypesChanger.IncrementExperienceOfFirstTrainerInArray(sourceArrayOfValueType);

            Trace.TraceInformation("Expected, that the first item of the source array " +
                                   "is changed in the caller (Experience is incremented)");
            sourceArrayOfValueType[0].Experience
                .Should()
                .BeGreaterThan(expectedArrayOfValueType[0].Experience);


            var sourceListOfValueType =
                new List<TrainerValueType> {new TrainerValueType("Mikey", 5), new TrainerValueType("Beth", 3)};
            Trace.TraceInformation(
                $"Create a generic list of items with value type TrainerValueType. Type: List<TrainerValueType>, value = '{Utilities.CreateString(sourceListOfValueType)}'.");

            Trace.TraceInformation(
                "Pass it to the method, which should increment a property of the first item by index");
            Action act = () => TypesChanger.IncrementExperienceOfFirstTrainerInList(sourceListOfValueType);

            act.Should()
                .Throw<Exception>();

            Trace.TraceInformation(
                "The difference occurs because indexers of an array and a list work in a different way. " +
                "Indexer of an array returns a reference to the item of an array, that's why we can modify our item and all changes will be saved by its reference. " +
                "But indexer of a list returns a copy of the item of value type. A new copy will be returned each time, we get an item by index. " +
                "That's why compiler knows, that the operation is meaningless, you will lose your changes even locally (in the same method), and compiler prevents a runtime error with a compile-time error.");
        }
    }
}