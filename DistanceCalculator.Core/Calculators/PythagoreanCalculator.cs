using DistanceCalculator.Core.Calculators.Abstract;
using DistanceCalculator.Core.Extensions;
using DistanceCalculator.Core.Models;
using System;

namespace DistanceCalculator.Core.Calculators
{
    /// <summary>
    /// Calculates distance using ‘Pythagorean theorem’ formula
    /// </summary>
    public class PythagoreanCalculator : CalculatorBase
    {
        protected override double CalculateDistance(Point pointA, Point pointB)
        {
           var result = Math.Sqrt(Math.Pow(pointA.Longitude - pointA.Latitude, 2) +
                      Math.Pow(pointB.Longitude - pointB.Latitude, 2) * 1.0);
            
            return result;
        }
    }
}
