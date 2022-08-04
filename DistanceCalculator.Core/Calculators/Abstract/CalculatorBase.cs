using DistanceCalculator.Core.Models;
using System;

namespace DistanceCalculator.Core.Calculators.Abstract
{
    public abstract class CalculatorBase
    {
        /// <summary>
        /// Earth radius in meters
        /// </summary>
        protected const int Radius = 6371000;

        /// <summary>
        /// Number of digits for rounding
        /// </summary>
        private readonly int _digits;

        protected CalculatorBase(int digits = 3)
        {
            if (digits < 0)
            {
                throw new ArgumentException("Should be greater or equal to zero", nameof(digits));
            }

            _digits = digits;
        }

        /// <summary>
        /// Calculates distance in meters
        /// </summary>
        /// <param name="pointA">Point A coordinates</param>
        /// <param name="pointB">Point B coordinates</param>
        /// <returns></returns>
        protected abstract double CalculateDistance(Point pointA, Point pointB);

        /// <summary>
        /// Returns distance in meters
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>8
        /// <returns></returns>
        public double GetDistance(Point pointA, Point pointB)
        {
            var distance = Math.Round(CalculateDistance(pointA, pointB), _digits);

            return distance;
        }
    }
}
