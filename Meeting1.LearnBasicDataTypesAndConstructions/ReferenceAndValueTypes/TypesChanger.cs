using System;
using System.Collections.Generic;

namespace Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes
{
    internal static class TypesChanger
    {
        // ↓ #region directive help to split logic parts of the code.
        //It is not necessary to use it, if your code is well structured
        //but here we will have a lot of methods, which we will use to
        //learn mutations of types, that's why we will split it.
        //
        //(It is only syntax sugar which is available in several code editors).

        #region Play with value types 

        public static int IncrementInteger(int sourceInteger)
        {
            sourceInteger++;

            return sourceInteger;
        }

        public static TrainerValueType IncrementExperienceOfTrainer(TrainerValueType trainer)
        {
            trainer.Experience++;

            return trainer;
        }

        public static TrainerValueType AssignTraineesToTrainer(TrainerValueType trainer)
        {
            trainer.Trainees = new[] {new TraineeReferenceType("Bill", 9), new TraineeReferenceType("Bob", 15)};

            return trainer;
        }

        #endregion

        #region Play with reference types

        public static TraineeReferenceType IncrementAssessmentOfTrainee(TraineeReferenceType trainee)
        {
            trainee.Assessment++;

            return trainee;
        }

        public static string ConcatenateStringWithGuid(string sourceString)
        {
            sourceString += Guid.NewGuid();

            return sourceString;
        }

        public static int[] IncrementFirstItemByIndexThenOverrideArray(int[] sourceArray)
        {
            sourceArray[0]++;
            sourceArray = new[] {-3, -1, -2, -3, -4};

            return sourceArray;
        }

        public static int[] IncrementFirstItemByIndexThenOverrideArray(ref int[] sourceArray)
        {
            sourceArray[0]++;
            sourceArray = new[] {-3, -1, -2, -3, -4};

            return sourceArray;
        }

        public static void IncrementExperienceOfFirstTrainerInArray(TrainerValueType[] sourceArray) =>
            sourceArray[0].Experience++;

        public static void IncrementExperienceOfFirstTrainerInList(List<TrainerValueType> sourceList)
        {
            //If you uncomment the line below, you will get an error: CS1612  Cannot modify the return value of 'List<TrainerValueType>.this[int]' because it is not a variable
            //sourceList[0].Experience++;

            throw new InvalidOperationException("sourceList[0].Name = \"changed name\"; " +
                                                "=> CS1612  Cannot modify the return value of 'List<TrainerValueType>.this[int]' because it is not a variable");
        }

        #endregion
    }
}