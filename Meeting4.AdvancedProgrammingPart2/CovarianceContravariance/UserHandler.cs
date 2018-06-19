using System.Diagnostics;
using Meeting4.AdvancedProgrammingPart2.BuildinDelegatesSamples;

namespace Meeting4.AdvancedProgrammingPart2.CovarianceContravariance
{
    public class UserHandler
    {
        public static Name PrintName(Name userInfo)
        {
            Trace.TraceInformation($"First name of user: '{userInfo.FirstName}'.");
            return userInfo;
        }

        public static FullName PrintFullName(FullName userInfo)
        {
            Trace.TraceInformation($"Full name of user: '{userInfo.FirstName} {userInfo.LastName}'.");
            return userInfo;
        }

        public static Name ToName(FullName fullName) => fullName;

        public static Employee CreateEmployee(FullName fullName, int salary) => new Employee(fullName.FirstName, fullName.LastName, salary);
    }
}