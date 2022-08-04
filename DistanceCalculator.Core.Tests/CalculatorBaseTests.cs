using DistanceCalculator.Core.Calculators.Abstract;
using DistanceCalculator.Core.Models;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace DistanceCalculator.Core.Tests
{
    public class CalculatorBaseTests
    {
        [Test]
        public void GetDistance_NoRounding_Returns_OriginalValue()
        {
            // Arrange
            double distance = 1000.5;
            var calculator = new FakeCalculator(distance);

            // Act
            var res = calculator.GetDistance(default, default);

            // Assert
            Assert.AreEqual(distance, res);
        }

        [Test]
        public void GetDistance_DefaultRounding_Returns_RoundedValue()
        {
            // Arrange
            double distance = 1000.5054854;
            var calculator = new FakeCalculator(distance);

            // Act
            var res = calculator.GetDistance(default, default);

            // Assert
            Assert.AreEqual(1000.505, res);
        }

        [Test]
        public void GetDistance_CustomRounding_Returns_RoundedValue()
        {
            // Arrange
            double distance = 1000.5054854;
            var calculator = new FakeCalculator(distance, 2);

            // Act
            var res = calculator.GetDistance(default, default);

            // Assert
            Assert.AreEqual(1000.51, res);
        }

        [Test]
        public void GetDistance_CustomRounding_ZeroDigits_Returns_RoundedValue()
        {
            // Arrange
            double distance = 1000.5054854;
            var calculator = new FakeCalculator(distance, 0);

            // Act
            var res = calculator.GetDistance(default, default);

            // Assert
            Assert.AreEqual(1001, res);
        }

        [Test]
        public void GetDistance_NagativeDigits_Throws_Exception()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new FakeCalculator(1000, -1));
        }

        private class FakeCalculator : CalculatorBase
        {
            private readonly double _distance;
            public FakeCalculator(double distance) : base()
            {
                _distance = distance;
            }

            public FakeCalculator(double distance, int didits) : base(didits)
            {
                _distance = distance;
            }

            protected override double CalculateDistance(Point pointA, Point pointB)
            {
                return _distance;
            }
        }
    }
}
