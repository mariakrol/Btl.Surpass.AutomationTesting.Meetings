namespace Meeting4.AdvancedProgrammingPart2.BuildinDelegatesSamples
{
    public class Employee
    {
        public Employee(string firstName, string lastName, int salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        private string FirstName { get; }

        private string LastName { get; }

        private int Salary { get; }

        public override string ToString() => $"Employee {FirstName} {LastName} with salary ${Salary}";
    }
}