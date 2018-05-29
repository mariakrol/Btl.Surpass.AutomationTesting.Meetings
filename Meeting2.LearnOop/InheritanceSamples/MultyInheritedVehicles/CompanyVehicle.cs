using System;
using Meeting2.LearnOop.InheritanceSamples.Vehicles;

namespace Meeting2.LearnOop.InheritanceSamples.MultyInheritedVehicles
{

    // If you uncomment code below, you will got an error: 'CS1721  Class 'CompanyVehicle' cannot have multiple base classes: 'Vehicle' and 'Asset'
    // Because C# does not allow multiple class inheritance
    // But it is possible to inherit class and interfaces
    internal class CompanyVehicle : Vehicle, /*Asset,*/ IAsset, IInsured
    {
        public CompanyVehicle(int speed) : base(speed)
        {
        }

        public int Cost { get; set; }

        public DateTime Validity { get; set; }

        public int SumInsured { get; set; }

        public override void IndicateTurn(bool isRightTurn) => throw new NotImplementedException();
    }
}