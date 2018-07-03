using Common.Logging;
using NUnit.Framework;

namespace Meeting5.IntroductionToAutomatedTesting
{
    [TestFixture]
    internal static class Logging
    {
        private static readonly ILog Log = LogManager.GetLogger("testLogger");

        [Test]
        public static void A_LogMessages()
        {
            Log.Trace("This is a trace...");
            Log.Info("This is an info message...");
            Log.Warn("This is a warning...");
            Log.Error("This is an error...");
            Log.Fatal("This is a fatal error...");
        }
    }
}
