using System;
using FluentAssertions;
using Meeting2.LearnOop.EncapsulationSamples;
using NUnit.Framework;

namespace Meeting2.LearnOop
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class B_Encapsulation
    {
        /// <summary>
        /// Encapsulation is an object-oriented programming concept that binds together the data
        /// and functions that manipulate the data,
        /// and that keeps both safe from outside interference and misuse.
        /// </summary>
        [Test]
        public static void A_EncapsulationAsBindingTogetherDataAndFunctions()
        {
            var color = "Yellow";
            var specialGift = new SpecialFilledAndDecoratedGiftBox(2, color);

            // The color is a data of specialGift object.
            // It is stored in the field and protected from corruption by the property Color.
            // We cannot override data with incorrect value.
            specialGift.Color = string.Empty;

            specialGift
                .Color
                .Should()
                .Be(color);

            // The gift is a data of specialGift object too.
            // It is stored in the field and protected from corruption and incorrect filling by the method PackGift.
            // We cannot override data or store an incorrect one.

            Action packNothing = () => specialGift.PackGift(null);
            packNothing.Should().Throw<ArgumentException>();

            specialGift
                .PackGift("Tale");

            Action packAgain = () => specialGift.PackGift("Poem");
            packAgain.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Encapsulation also allows us to pay no attention to the
        /// internal implementation of class.
        /// We can only call a method and it made everything under the hood
        /// </summary>
        [Test]
        public static void B_EncapsulationAsHidingOfRealization()
        {
            var deliveryService = new DeliveryService();
            // We do not know, how delivery service works, 
            // we give them our package and they must to deliver it.

            var smallSpecialGift = new SpecialFilledAndDecoratedGiftBox(2, "Yellow");
            deliveryService.DeliverGift(smallSpecialGift);

            var bigSpecialGift = new SpecialFilledAndDecoratedGiftBox(17, "Red");
            deliveryService.DeliverGift(bigSpecialGift);
        }
    }
}