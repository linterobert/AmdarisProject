using Bidding_app.Entities;
using Bidding_app.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding_app
{
    internal class Test
    {
       

        [TestFixture]
        public class HasStartPriceProperty
        {
            [Test]
            public bool ReturnTrueIfPriceIsHigherThan0(double startPrice)
            {
                return startPrice >= 0;
            }
        }
        [TestFixture]
        public class IncreasePriceTest
        {
            [TestCase(12,15,ExpectedResult = 20)]
            public double IncreasePrice(double initial, double newOffer)
            {
                return newOffer + newOffer / 3;
            }

        }

        [Test]
        public void ItShouldCreateProduct()
        {
            var mockTest = new Mock<IProduct>();
            mockTest.Setup(m => m.CreateProduct())
                .Returns(true);
        }
    }
}
