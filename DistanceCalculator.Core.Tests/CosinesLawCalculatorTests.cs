using DistanceCalculator.Core.Calculators;
using DistanceCalculator.Core.Models;
using NUnit.Framework;

namespace DistanceCalculator.Core.Tests
{
    public class CosinesLawCalculatorTests
    {
        [Test]
        public void GetDistance_ZeroCoordinates_Returns_Zero()
        {
            // Arrange
            var calculator = new CosinesLawCalculator();

            var pointA = new Point();
            var pointB = new Point();

            // Act
            var res = calculator.GetDistance(pointA, pointB);

            // Assert
            Assert.AreEqual(0, res);
        }

        [Test]
        public void GetDistance_Returns_Cordinates()
        {
            // Arrange
            var calculator = new CosinesLawCalculator();

            var pointA = new Point(53.297975, -6.372663);
            var pointB = new Point(41.385101, -81.440440);

            // Act
            var res = calculator.GetDistance(pointA, pointB);

            // Assert
            Assert.AreEqual(5536338.682, res);
        }
    }
}
