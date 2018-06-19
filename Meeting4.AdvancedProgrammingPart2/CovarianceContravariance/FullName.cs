namespace Meeting4.AdvancedProgrammingPart2.CovarianceContravariance
{
    public class FullName : Name
    {
        public FullName(string firstName, string lastName) : base(firstName)
        {
            LastName = lastName;
        }

        public string LastName { get; }
    }
}