using Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes;

namespace Meeting2.LearnOop
{
    internal static class TreineeExtensions
    {
        public static void ChangeAssesment(this TraineeReferenceType trainee, int assesment)
            => trainee.Assessment = assesment;
    }
}
