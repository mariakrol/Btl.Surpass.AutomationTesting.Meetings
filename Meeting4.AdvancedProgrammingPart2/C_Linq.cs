using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Meeting4.AdvancedProgrammingPart2
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class C_Linq
    {
        [Test]
        public static void A_SelectFromCollection()
        {
            int[] scores = { 97, 92, 81, 60 };

            IEnumerable<int> highScoresQuery =
                from score in scores
                where score > 80
                orderby score descending
                select score;

            foreach (var i in highScoresQuery)
            {
                Trace.TraceInformation($"{i} ");
            }
        }

        [Test]
        public static void B_CompareLinqAndFluentSyntax()
        {
            string[] fullNames = { "Anne Williams", "John Fred Smith", "Sue Green" };

            var linqQuery =
                from fullName in fullNames
                from name in fullName.Split()
                orderby fullName, name
                select $"{name} came from {fullName}";

            var methodsChain = fullNames
                .SelectMany(fullName => fullName.Split().Select(name => new { Name = name, FullName = fullName }))
                .OrderBy(nameInfo => nameInfo.FullName)
                .ThenBy(nameInfo => nameInfo.Name)
                .Select(nameInfo => $"{nameInfo.Name} came from {nameInfo.FullName}");

            linqQuery
                .Should()
                .BeEquivalentTo(methodsChain);
        }

        [Test]
        public static void C_MixLinqAndFluent()
        {
            Customer[] customers = {
                new Customer("Anne Williams", "Strange City", new Customer.Purchase("food", 200),
                    new Customer.Purchase("drinks", 100)),
                new Customer("John Fred Smith", "Tokyo", new Customer.Purchase("electronics", 2000))
            };

            var customerPurchasesInformation =
                from customer in customers
                let totalSpend = customer.Purchases.Sum(p => p.Price)    // Method syntax here
                where totalSpend > 1000
                from purchase in customer.Purchases
                select new { purchase.Description, TotalSpend = totalSpend, customer.Address };

            Trace.TraceInformation(string.Join("; ", customerPurchasesInformation.Select(purchase => $"{purchase.Description}, {purchase.TotalSpend}")));
        }
    }
}