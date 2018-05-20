using System;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.ParametersAndModificators
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class B_ParameterModifiers
    {
        /// <summary>
        /// Compare result of this example with 
        /// Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes.C_ChangeItemInArrayOfItemsWithValueType()
        /// In the previous example we cannot overwrite a reference to an array, but here we pass the reference to the array by reference,
        /// using ref modifier, and when we overwrite an array at the called method, we overwrite a reference in the caller 
        /// </summary>
        [Test]
        public static void A_RefModifierPassEverythingByReference()
        {
            var sourceArray = new[] {1, 2, 3};

            Trace.TraceInformation(
                "If you use a ref modifier for a parameter of reference type, then reference on it will be passed by reference.");
            var changedArray = TypesChanger.IncrementFirstItemByIndexThenOverrideArray(ref sourceArray);

            Trace.TraceInformation(
                "That's why, if it will be overwritten in the called method, the caller will be affected too.");

            sourceArray
                .Should()
                .HaveCount(changedArray.Length)
                .And
                .OnlyContain(item => changedArray.Any(changedItem => changedItem == item));
        }

        [Test]
        public static void B_OutParameterShouldBeAssignedInCalledMethod()
        {
            var sourceArray = new[] {1, 2, 3};
            int[] oldArray = new int[sourceArray.Length];
            Array.Copy(sourceArray, oldArray, sourceArray.Length);

            Trace.TraceInformation(
                "If you use an out modifier for a parameter, it also be passed by reference and value of argument will always be overwritten.");
            ReturnArrayByOutParameter(out sourceArray);
        }

        [Test]
        public static void C_PassParamsAsSeparateObjects()
        {
            Trace.TraceInformation(
                "params modifier allows us to pass any number of separate arguments, which will be handled as a single parameter (array).");
            var arrayOf3Items = CreateArrayFromParams(1, 2, 3);

            var arrayOf5Items = CreateArrayFromParams(1, 2, 3, 4, 5);

            arrayOf3Items
                .Should()
                .NotHaveCount(arrayOf5Items.Length);
        }

        [Test]
        public static void C_PassParamsAsArray()
        {
            Trace.TraceInformation(
                "params modifier allows us to pass any number of separate arguments, which will be handled as a single parameter (array).");
            var arrayOf3Items = CreateArrayFromParams(new[] {1, 2, 3});

            var arrayOf5Items = CreateArrayFromParams(new[] {1, 2, 3, 4, 5});

            arrayOf3Items
                .Should()
                .NotHaveCount(arrayOf5Items.Length);
        }

        private static void ReturnArrayByOutParameter(out int[] sourceArray)
            => sourceArray = new[] {-3, -1, -2, -3, -4};

        private static int[] CreateArrayFromParams(params int[] items)
        {
            var arrayFromParams = new int[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                arrayFromParams[i] = items[i];
            }

            return arrayFromParams;
        }
    }
}