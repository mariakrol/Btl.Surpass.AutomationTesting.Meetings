using System;
using System.Diagnostics;
using Meeting2.LearnOop.InheritanceSamples.Vehicles;

namespace Meeting2.LearnOop.CompositionSamples
{
    internal class Tractor : MotorVehicle
    {
        public Tractor(int speed, int yearOfAssembly, int wheelsCount) : base(speed)
        {
            YearOfAssembly = yearOfAssembly;
            Wheels = new Wheel[wheelsCount];

            for (var i = 0; i < wheelsCount; i++)
            {
                Wheels[i] = new Wheel();
            }

            Crane = new LoadingCrane(10);
        }

        private Wheel[] Wheels { get; }

        private LoadingCrane Crane { get; }

        private int YearOfAssembly { get; }

        public override string ToString()
            =>
                $"Tractor of {YearOfAssembly} assembly year with {Wheels.Length} wheels and crane of {Crane.CarryingCapacity} ton.";

        public void Turn(bool isTurnRight)
        {
            foreach (var wheel in Wheels)
            {
                wheel.Turn(isTurnRight);
            }
        }

        public void LoadСargo(int weight)
        {
            if (weight > Crane.CarryingCapacity)
            {
                throw new Exception("Too heavy");
            }
            Crane.Load();
        }

        private class LoadingCrane
        {
            public LoadingCrane(int carryingCapacity)
            {
                CarryingCapacity = carryingCapacity;
            }

            public int CarryingCapacity { get; }

            public void Load() => Trace.TraceInformation("Cargo is loaded");
        }
    }
}