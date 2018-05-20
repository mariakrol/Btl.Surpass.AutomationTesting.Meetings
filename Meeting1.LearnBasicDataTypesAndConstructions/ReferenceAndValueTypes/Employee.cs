using System;
using System.Diagnostics;

namespace Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes
{
    internal class Employee : IEquatable<Employee>
    {
        public Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        private string Name { get; }

        private int Salary { get; }

        public override bool Equals(object otherEmploee)
        {
            if (!ReferenceEquals(this, otherEmploee) || ReferenceEquals(otherEmploee, null) ||
                !(otherEmploee is Employee emploee))
            {
                return false;
            }
            return Equals(emploee);
        }

        public override string ToString() => $"Name: '{Name}', salary: {Salary}";

        public bool Equals(Employee otherEmployee)
        {
            //The debug print is used here it is a trick,
            //which allows us to get useful information or
            //check was method called implicitly or not without breakpoint
            Trace.TraceInformation($"Equals method is called on Employee '{this}' to compare with '{otherEmployee}'");

            return otherEmployee != null && Name.Equals(otherEmployee.Name);
        }

        public override int GetHashCode()
        {
            Trace.TraceInformation($"GetHashCode method is called on Employee '{this}'");

            return Salary.GetHashCode();
        }
    }
}