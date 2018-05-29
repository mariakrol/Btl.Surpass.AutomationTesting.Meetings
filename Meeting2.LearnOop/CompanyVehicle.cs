using Meeting2.LearnOop.InheritanceSamples;

namespace Meeting2.LearnOop
{
    internal class CompanyVehicle : Vehicle, IAsset
    {
        public CompanyVehicle(int speed) : base(speed)
        {
        }

        public int Cost { get; set; }

        public override void IndicateTurn(bool isRightTurn)
        {
            throw new System.NotImplementedException();
        }
    }
}