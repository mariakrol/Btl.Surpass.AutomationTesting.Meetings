using System.Diagnostics;

namespace Meeting2.LearnOop.EncapsulationSamples
{
    internal class DeliveryService
    {
        public void DeliverGift(SpecialFilledAndDecoratedGiftBox gift)
        {
            Trace.TraceInformation(gift._boxSideSize > 5
                ? "Deliver by courier"
                : "Put in the post box and send the code");
        }
    }
}