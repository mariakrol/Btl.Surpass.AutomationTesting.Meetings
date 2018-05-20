using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes
{
    [TestFixture] // <- Attribute for class with tests, ignore it for now
    /*
     * You see ReSharper comment below, it is needed because we use incorrect name style here,
     * but we know it and we do not want to see a warning.
     * 
     * It is not good to ignore warnings, but sometimes we had to do it if there is no any way.
     * But always try to find a solution, which helps to avoid such ugly bypass
     */
    // ReSharper disable once InconsistentNaming
    internal static class A_ChangesOfValueType
    {
        /// <summary>
        /// When we operate on value type and pass it to a method,
        /// we have no any changes at a caller,
        /// because each called method got a copy of a value.
        /// 
        /// Here we create an integer variable and pass it to the method,
        /// which increments a value and return it back.
        /// We can see, that the called method return a new value (incremented),
        /// but the caller still has an old one.
        /// </summary>
        [Test] // <- Attribute for test method, ignore it too
        public static void A_ChangeOfValueTypePassedByValueIsNotTakeEffectInCaller()
        {
            var sourceInteger = 5;
            var expectedInteger = sourceInteger;
            Trace.TraceInformation($"Create a variable of a value type. Type: integer, value = '{sourceInteger}'.");

            Trace.TraceInformation("Pass it to the method, which perform incrementing of passed values.");
            var changedInteger = TypesChanger.IncrementInteger(sourceInteger);

            Trace.TraceInformation(
                "Expected, that the value in the caller is not affected, but the value in the method, " +
                "which was called, is incremented. It occurs because value type is passed by value. " +
                "It means a copy of the value is passed to the called method.");

            Trace.TraceInformation(
                $"Compare the source integer with expected (Should be the same): source = '{sourceInteger}'; expected = '{expectedInteger}'.");
            sourceInteger
                .Should()
                .Be(expectedInteger);
            // ↑ 'Should', 'Be', 'BeGreaterThan' and other methods are added from 
            // FluentAssertions library, we will go deeper with it later,
            // now you only need to know, that it helps us to check objects
            Trace.TraceInformation(
                $"Compare changed integer with the original (The changed value should be greater than the original): changed = '{changedInteger}'; original = '{sourceInteger}'.");
            changedInteger
                .Should()
                .BeGreaterThan(sourceInteger);
        }

        /// <summary>
        /// Complex value types are passed by value too.
        /// It means, that a called method get a copy of 
        /// a value with copied fields and properties.
        /// </summary>
        [Test]
        public static void B_ChangeOfFieldWithValueTypeForComplexValueTypePassedByValueIsNotTakeEffectInCaller()
        {
            var sourceTrainer = new TrainerValueType("Dan", 2);
            var expectedTrainer = sourceTrainer;
            Trace.TraceInformation(
                $"Create a variable of a complex value type. Type: TrainerValueType, value = '{sourceTrainer}'.");

            Trace.TraceInformation("Pass it to the method, which increment property 'Experience' (value type - int).");
            var changedTrainer = TypesChanger.IncrementExperienceOfTrainer(sourceTrainer);

            Trace.TraceInformation(
                "Expected, that the value in the caller is not affected, but the value in the method, " +
                "which was called, is incremented. It occurs because the called method got a copy of a complex value type.");

            Trace.TraceInformation(
                $"Compare the source experience with expected (Should be the same): source = '{sourceTrainer.Experience}'; expected = '{expectedTrainer.Experience}'.");
            sourceTrainer.Experience
                .Should()
                .Be(expectedTrainer.Experience);

            Trace.TraceInformation(
                $"Compare changed experience with the original (The changed value should be greater than the original): changed = '{changedTrainer.Experience}'; original = '{sourceTrainer.Experience}'.");
            changedTrainer.Experience
                .Should()
                .BeGreaterThan(sourceTrainer.Experience);
        }

        /// <summary>
        /// If complex value type has field or properties of reference type, it changes nothing in the behavior.
        /// When we pass it to the method, we create a copy; fields and properties of reference type will be copied too
        /// (new references will be created).
        /// </summary>
        [Test]
        public static void C_ChangeOfFieldWithReferenceTypeForComplexValueTypePassedByValueIsNotTakeEffectInCaller()
        {
            var sourceTrainer = new TrainerValueType("Dan", 2);
            var expectedTrainer = sourceTrainer;
            Trace.TraceInformation(
                $"Create a variable of a complex value type with empty field (type of field - reference). Type: TrainerValueType (without trainees), value = '{sourceTrainer}'.");

            Trace.TraceInformation(
                "Pass it to the method, which add trainees (referenceType type - TraineeReferenceType).");
            var changedTrainer = TypesChanger.AssignTraineesToTrainer(sourceTrainer);

            Trace.TraceInformation(
                "Expected, that the value in the caller is not affected, but the trainer in the method, " +
                "which was called, has trainees. It occurs because the called method got a copy of a trainer " +
                "no matter the field 'Trainees' is a reference type, the field does not reference to the source reference.");

            Trace.TraceInformation(
                "Compare trainees of the source trainer with expected (Should be the same and empty): " +
                $"source = '{string.Join("; ", sourceTrainer.Trainees.Select(trainee => trainee.ToString()))}'; " +
                $"expected = '{string.Join("; ", expectedTrainer.Trainees.Select(trainee => trainee.ToString()))}'.");
            // ↑ We use LINQ query here (Select method) we will go deeper with it later, just ignore it for now. 

            sourceTrainer.Trainees
                .Should()
                .BeEmpty();
            sourceTrainer.Trainees
                .Should()
                .BeSameAs(expectedTrainer.Trainees);

            Trace.TraceInformation(
                "The changed trainer should have trainees: " +
                $"changed trainees = '{string.Join("; ", changedTrainer.Trainees.Select(trainee => trainee.ToString()))}'.");
            changedTrainer.Trainees
                .Should()
                .OnlyContain(trainee => trainee != null);
        }
    }
}