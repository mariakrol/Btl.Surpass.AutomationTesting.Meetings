using System;

namespace Meeting3.AdvancedProgrammingPart1.ErrorWithException
{
    [Serializable]
    public class DriverAssignException : Exception
    {
        public DriverAssignException(string message) : base(message)
        {
        }
    }
}