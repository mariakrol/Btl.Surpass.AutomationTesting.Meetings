using System.Diagnostics;
using NUnit.Framework;

namespace Meeting1.LearnBasicDataTypesAndConstructions.ParametersAndModificators
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class A_NamedAndOptionalParameters
    {
        [Test]
        public static void A_NamedParameters()
        {
            Trace.TraceInformation(
                "You can use names of parameters, but if you add names not for all of then, they should go at the end");
            PrintOrderDetails("Super seller", 5, productName: "Sponge");

            Trace.TraceInformation("If you change order, you should add names for each parameter");
            PrintOrderDetails(productName: "Sponge", sellerName: "Super seller", orderNum: 6);

            Trace.TraceInformation(
                "If you use an incorrect order of parameters, and miss some names, you will got an error.");
            // If you uncomment following line, you got an error 'CS1738  Named argument specifications must appear after all fixed arguments have been specified.'
            //PrintOrderDetails(productName: "Sponge", "Super seller", 7);
        }

        [Test]
        public static void B_OptionalParameters()
        {
            Trace.TraceInformation("Optional parameter can be overwritten");
            PrintOrderWithDefaultDetails("Super seller", 5, productName: "Skate");

            Trace.TraceInformation("If you miss optional parameter, default value will be used");
            PrintOrderWithDefaultDetails("Super seller", 6);
        }

        [Test]
        public static void C_CombinationOfNamedAndOptionalParameters()
        {
            Trace.TraceInformation("You can override optional parameter and change it order in the list of arguments");
            PrintOrderWithDefaultDetails(productName: "Sponge", sellerName: "Super seller", orderNum: 5);

            Trace.TraceInformation("You can use parameter by default and change order of other parameters");
            PrintOrderWithDefaultDetails(orderNum: 6, sellerName: "Super seller");
        }

        private static void PrintOrderDetails(string sellerName, int orderNum, string productName)
            => Trace.TraceInformation($"Seller: {sellerName}, Order #: {orderNum}, Product: {productName}");

        private static void PrintOrderWithDefaultDetails(string sellerName, int orderNum,
            string productName = "Bicycle")
            => Trace.TraceInformation($"Seller: {sellerName}, Order #: {orderNum}, Product: {productName}");
    }
}