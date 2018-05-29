using System;

namespace Meeting2.LearnOop
{
    internal class Program
    {
        public static void Main()
        {
            var primitiveVehicle = new Vehicle(5);

            Console.WriteLine($"Current speed: {primitiveVehicle.IncreaseSpeed(10)}");

            Console.WriteLine($"Max weight of vehicle: {Vehicle.GetMaxWeight()}");
        }
    }
}
