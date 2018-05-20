namespace Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes
{
    /// <summary>
    /// Here you see an incorrect name style.
    /// Postfix 'ValueType' or 'ReferenceType'
    /// is used to show you which kind of type
    /// we create now because we want to depict a difference in a behavior. 
    /// </summary>
    public struct TrainerValueType
    {
        public TrainerValueType(string name, int experience, params TraineeReferenceType[] trainees)
        {
            Name = name;
            Experience = experience;
            Trainees = trainees;
        }

        private string Name { get; }

        public int Experience { get; set; }

        public TraineeReferenceType[] Trainees { get; set; }

        public override string ToString() => "Name: " + Name + "; experience: " + Experience;
    }
}