namespace Meeting4.AdvancedProgrammingPart2.CovarianceContravariance
{
    public class Name
    {
        protected Name(string firstName)
        {
            FirstName = firstName;
        }

        public string FirstName { get; }

        public override string ToString() => $"User name: '{FirstName}'";
    }
}