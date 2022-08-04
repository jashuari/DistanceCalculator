using DistanceCalculator.Core.Calculators.Abstract;
using DistanceCalculator.Core.Extensions;
using DistanceCalculator.Core.Models;
using System;

namespace DistanceCalculator.Core.Calculators
{
    /// <summary>
    /// Calculates distance based on the Spherical Law of Cosines
    /// </summary>
    public class CosinesLawCalculator : CalculatorBase
    {
        protected override double CalculateDistance(Point pointA, Point pointB)
        {
            var a = (90 - pointB.Latitude).ToRadians();
            var b = (90 - pointA.Latitude).ToRadians();
            var phi = (pointA.Longitude - pointB.Longitude).ToRadians();

            var d = Math.Acos(Math.Cos(a)*Math.Cos(b) + Math.Sin(a)*Math.Sin(b)*Math.Cos(phi));

            var distance = Radius * d;

            return distance;
        }
    }
}
