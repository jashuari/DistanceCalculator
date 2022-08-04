using DistanceCalculator.Core.Calculators;
using DistanceCalculator.Core.Models;
using NUnit.Framework;

namespace DistanceCalculator.Core.Tests
{
    public class PythagoreanCalculatorTests
    {
        [Test]
        public void GetDistance_ZeroCoordinates_Returns_Zero()
        {
            // Arrange
            var calculator = new PythagoreanCalculator();

            var pointA = new Point();
            var pointB = new Point();

            // Act
            var res = calculator.GetDistance(pointA, pointB);

            // Assert
            Assert.AreEqual(0, res);
        }

        [Test]
        public void GetDistance_Returns_Five()
        {
            // Arrange
            var calculator = new PythagoreanCalculator();

            var pointA = new Point(1, 4);
            var pointB = new Point(1, 5);

            // Act
            var res = calculator.GetDistance(pointA, pointB);

            // Assert
            Assert.AreEqual(5, res);
        }
    }
}
