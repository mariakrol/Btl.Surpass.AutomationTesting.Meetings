using System.Diagnostics;

namespace Meeting2.LearnOop.ClassesWithConstructors
{
    internal class FilledColoredGiftBox
    {
        private static string DeliveryService;

        static FilledColoredGiftBox()
        {
            DeliveryService = "DHL";
        }

        private FilledColoredGiftBox(object gift)
        {
            Gift = gift;
        }

        public FilledColoredGiftBox(object gift, string boxColor) : this (gift)
        {
            Trace.TraceInformation("In the constructor with two parameters - 'gift', 'box color'.");

            Color = boxColor;
        }

        public object Gift { get; }

        public string Color { get; }

        public void PlaySong(string name)
        {
            Trace.TraceInformation($@"Happy Birthday to you,
                                     Happy Birthday to you,
                                     Happy Birthday dear {name},
                                     Happy Birthday to you!");
        }

        public void PrintCongratulation()
            => Trace.TraceInformation($"Here is our gift for you, it is the {Gift}, and it is boxed to the {Color} cover. Enjoy and be happy!");

        public static string GetDeliveryServiceName() => DeliveryService;

        public static string ChangeDeliveryServiceName(string deliveryServiceName) => DeliveryService = deliveryServiceName;
    }
}