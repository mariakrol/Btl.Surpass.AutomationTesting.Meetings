namespace Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes
{
    public class TraineeReferenceType
    {
        private TraineeReferenceType(string name)
        {
            Name = name;
        }

        public TraineeReferenceType(string name, int assessment) : this(name)
        {
            Assessment = assessment;
        }

        private string Name { get; }

        public int Assessment { get; set; }


        /// <summary>
        /// Here you see the 'expression bodied' notation of method (=>).
        /// This notation is also available for properties.
        /// To create an 'expression bodied' method you should use round brackets (with or without parameters).
        /// To create an 'expression bodied' property you should not use brackets.
        /// If you use it, you do not need to use braces and return directive.
        /// If your method returns something, you should specify a returned type (here - string),
        /// result value will be calculated at runtime by right part and returned.
        /// </summary>
        /// <returns>A string equivalent of object</returns>
        public override string ToString() => "Name: " + Name + "; assessment: " + Assessment;
    }
}