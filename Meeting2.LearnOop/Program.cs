using System;
using Meeting1.LearnBasicDataTypesAndConstructions.ReferenceAndValueTypes;

namespace Meeting2.LearnOop
{
    internal class Program
    {
        public static void Main()
        {
            var primitiveVehicle = new MotorVehicle(5);

            Console.WriteLine($"Current speed: {primitiveVehicle.IncreaseSpeed(10)}");

            //Console.WriteLine($"Max weight of vehicle: {Vehicle.GetMaxWeight()}");

            TraineeReferenceType trainee = new TraineeReferenceType("Bill", 2);
            trainee.ChangeAssesment(5);

            Console.WriteLine(trainee);

            var bicycle = new Bicycle(12);
            bicycle.IncreaseSpeed(2);

            var washer = new CarWash();

            washer.Wash(primitiveVehicle);
            washer.Wash(bicycle);

            bicycle.ChangeColor("Red");

            Console.WriteLine(bicycle.Color);

            ((Vehicle) bicycle).ChangeColor("black");
            Console.WriteLine(bicycle.Color);

        }
    }
}
